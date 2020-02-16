using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
    /// Message tags enable sending important and personally relevant 1:1 updates to users outside the standard messaging window.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageTag
    {
        /// <summary>
        /// Send the user reminders or updates for an event they have registered for (e.g., RSVP'ed, purchased tickets). This tag may be used for upcoming events and events in progress.
        /// </summary>
        [EnumMember(Value = "CONFIRMED_EVENT_UPDATE")]
        ConfirmedEventUpdate,

        /// <summary>
        /// Notify the user of an update on a recent purchase.
        /// </summary>
        [EnumMember(Value = "POST_PURCHASE_UPDATE")]
        PostPurchaseUpdate,

        /// <summary>
        /// Notify the user of a non-recurring change to their application or account.
        /// </summary>
        [EnumMember(Value = "ACCOUNT_UPDATE")]
        AccountUpdate
    }
}
