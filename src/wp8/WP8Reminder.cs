using System;
using System.Linq;
using System.Runtime.Serialization;

namespace de.julianstock.Cordova.Plugin.LocalNotificationWP8
{
    [DataContract]
    class WP8Reminder
    {
        /// <summary>
        /// The Title that is displayed
        /// </summary>
        [DataMember(IsRequired = false, Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The text that is displayed
        /// </summary>
        [DataMember(IsRequired = false, Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [DataMember(IsRequired = false, Name = "at")]
        public string At { get; set; }

        /// <summary>
        /// The badge that is displayed
        /// </summary>
        [DataMember(IsRequired = false, Name = "badge")]
        public string Badge { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [DataMember(IsRequired = false, Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The data that is displayed
        /// </summary>
        [DataMember(IsRequired = false, Name = "data")]
        public string Data { get; set; }
    }
}
