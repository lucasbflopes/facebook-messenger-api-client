using Newtonsoft.Json;
using System.Collections.Generic;

namespace Facebook.Messenger.Api.Model
{
    public class Message
    {
        /// <summary>
        /// Message text. Previews will not be shown for the URLs in this field. Use attachment instead. Must be UTF-8 and has a 2000 character limit. Text or attachment must be set.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// Previews the URL. Used to send messages with media or Structured Messages. Text or attachment must be set.
        /// </summary>
        [JsonProperty("attachment", NullValueHandling = NullValueHandling.Ignore)]
        public Attachment Attachment { get; set; }

        /// <summary>
        /// Optional. Array of quick_reply to be sent with messages
        /// </summary>
        [JsonProperty("quick_replies", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<QuickReply> QuickReplies { get; set; }

        /// <summary>
        /// Optional. Custom string that is delivered as a message echo. 1000 character limit.
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }
    }
}