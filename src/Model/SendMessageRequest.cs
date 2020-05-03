using Newtonsoft.Json;

namespace SendApi.Model
{
    public class SendMessageRequest
    {
        /// <summary>
        /// The messaging type of the message being sent.
        /// </summary>
        [JsonProperty("messaging_type", NullValueHandling = NullValueHandling.Ignore)]
        public MessagingType MessagingType { get; set; }

        /// <summary>
        /// Recipient object.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Message object. Cannot be sent with sender_action.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }

        /// <summary>
        /// Message state to display to the user. Cannot be sent with message. Must be sent as a separate request. When using sender_action, recipient should be the only other property set in the request.
        /// </summary>
        [JsonProperty("sender_action", NullValueHandling = NullValueHandling.Ignore)]
        public SenderAction? SenderAction { get; set; }

        /// <summary>
        /// Optional. Push notification type. Defaults to regular.
        /// </summary>
        [JsonProperty("notification_type", NullValueHandling = NullValueHandling.Ignore)]
        public NotificationType? NotificationType { get; set; }

        /// <summary>
        /// Optional. The message tag string.
        /// </summary>
        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public MessageTag? Tag { get; set; }
    }
}
