using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Facebook.Messenger.Api.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ButtonType
    {
        /// <summary>
        /// The URL Button opens a web page in the Messenger webview.
        /// </summary>
        [EnumMember(Value = "web_url")]
        WebUrl,

        /// <summary>
        /// The postback button sends a messaging_postbacks event to your webhook with the string set in the payload property.
        /// </summary>
        [EnumMember(Value = "postback")]
        Postback
    }
}