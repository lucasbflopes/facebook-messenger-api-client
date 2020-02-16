using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
    /// Message state to display to the user.
    /// Cannot be sent with message. Must be sent as a separate request.
    /// When using sender_action, recipient should be the only other property set in the request.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SenderAction
    {
        /// <summary>
        /// Display the typing bubble.
        /// </summary>
        [EnumMember(Value = "typing_on")]
        TypingOn,

        /// <summary>
        /// Remove the typing bubble.
        /// </summary>
        [EnumMember(Value = "typing_off")]
        TypingOff,


        /// <summary>
        /// Display the confirmation icon.
        /// </summary>
        [EnumMember(Value = "mark_seen")]
        MarkSeen
    }
}
