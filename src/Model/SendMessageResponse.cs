using Newtonsoft.Json;

namespace SendApi.Model
{
    public class SendMessageResponse
    {
        /// <summary>
        /// Unique ID for the message.
        /// </summary>
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Unique ID for the user.
        /// </summary>
        [JsonProperty("recipient_id")]
        public string RecipientId { get; set; }
    }
}
