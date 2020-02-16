using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Api.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuickReplyContentType
    {
        /// <summary>
        /// Sends a text button.
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        /// Sends a button allowing recipient to send the phone number associated with their account.
        /// </summary>
        [EnumMember(Value = "user_phone_number")]
        UserPhoneNumber,


        /// <summary>
        /// Sends a button allowing recipient to send the email associated with their account.
        /// </summary>
        [EnumMember(Value = "user_email")]
        UserEmail
    }
}
