using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using System;
using Microsoft.Phone.Scheduler;
using System.Collections.Generic;
using System.Diagnostics;
using de.julianstock.Cordova.Plugin.LocalNotificationWP8;

namespace Cordova.Extension.Commands
{
    public class LocalNotificationWP8 : BaseCommand
    {
        public void cancelAll(string jsonArgs)
        {
            IEnumerable<Reminder> oldReminders = ScheduledActionService.GetActions<Reminder>();
            foreach (Reminder tmpReminder in oldReminders)
            {
                try
                {
                    ScheduledActionService.Remove(tmpReminder.Name);
                }
                catch (Exception)
                {
                    Debug.WriteLine("couldn't cancel reminder: {0}", tmpReminder.Name);
                }
            }

            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, true));
        }

        public void schedule(string jsonArgs)
        {
            string[] args = null;
            WP8Reminder[] reminders = null;

            try
            {
                args = JsonHelper.Deserialize<string[]>(jsonArgs);
                reminders = JsonHelper.Deserialize<WP8Reminder[]>(args[0]);
            }
            catch (Exception)
            {
                // simply catch the exception, we handle null values and exceptions together
            }

            if (reminders == null)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION));
            }
            else
            {
                for (int i = 0; i < reminders.Length; i++)
                {
                    Reminder planReminder = new Reminder(reminders[i].Id);
                    planReminder.Title = reminders[i].Title;
                    planReminder.Content = reminders[i].Text;

                    DateTime beginTime = new DateTime(1970, 1, 1, 0, 0, 0);
                    beginTime = beginTime.AddSeconds(Int64.Parse(reminders[i].At) / 1000);

                    // @FIXME: we need to add 1 hour in germany, why?
                    beginTime = beginTime.AddHours(1);

                    DateTime endTime = beginTime;
                    endTime = endTime.AddMinutes(5);
                    planReminder.RecurrenceType = RecurrenceInterval.None;

                    if (beginTime > DateTime.Now && endTime > beginTime)
                    {
                        planReminder.BeginTime = beginTime;
                        planReminder.ExpirationTime = endTime;
                        ScheduledActionService.Add(planReminder);
                    }
                }

                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, true));
            }
        }

        public void getScheduledIds(string jsonArgs)
        {
            IEnumerable<Reminder> reminders = ScheduledActionService.GetActions<Reminder>();
            string reminderIds = "";
            foreach(Reminder reminder in reminders)
            {
                reminderIds += "," + reminder.Name;
            }

            if (reminderIds.Length > 0)
            {
                reminderIds = reminderIds.Substring(1);
            }

            DispatchCommandResult(new PluginResult(PluginResult.Status.OK, reminderIds));
        }
    }
}
