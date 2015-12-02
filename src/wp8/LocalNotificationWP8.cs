using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;

namespace de.julianstock.localnotificationwp8
{
    public class Echo : BaseCommand
    {
        public void echo(string options)
        {
            string optVal = null;

            try
            {
                optVal = JsonHelper.Deserialize<string[]>(options)[0];
            }
            catch(Exception)
            {
                // simply catch the exception, we handle null values and exceptions together
            }

            if (optVal == null)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION));
            }
            else
            {
                // ... continue on to do our work
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK, optVal));
            }
        }
    }
}
