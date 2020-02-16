using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
    /// Push notification type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        /// <summary>
        /// Sound/vibration.
        /// </summary>
        [EnumMember(Value = "REGULAR")]
        Regular,

        /// <summary>
        /// On-screen notification only.
        /// </summary>
        [EnumMember(Value = "SILENT_PUSH")]
        SilentPush,

        /// <summary>
        /// No notification.
        /// </summary>
        [EnumMember(Value = "NO_PUSH")]
        NoPush
    }
}
