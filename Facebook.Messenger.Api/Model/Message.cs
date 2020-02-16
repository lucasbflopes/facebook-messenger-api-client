using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    public class Message
    {
        /// <summary>
        /// Message text. Previews will not be shown for the URLs in this field. Use attachment instead. Must be UTF-8 and has a 2000 character limit. Text or attachment must be set.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Previews the URL. Used to send messages with media or Structured Messages. Text or attachment must be set.
        /// </summary>
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }

        /// <summary>
        /// Optional. Array of quick_reply to be sent with messages
        /// </summary>
        [JsonProperty("quick_replies")]
        public QuickReply[] QuickReplies { get; set; }

        /// <summary>
        /// Optional. Custom string that is delivered as a message echo. 1000 character limit.
        /// </summary>
        [JsonProperty("metadata")]
        public string Metadata { get; set; }

    }
}
