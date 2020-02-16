using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    public class QuickReply
    {
        /// <summary>
        /// Content type of quick reply.
        /// </summary>
        [JsonProperty("content_type")]
        public QuickReplyContentType ContentType { get; set; }

        /// <summary>
        /// Required if content_type is 'text'. The text to display on the quick reply button. 20 character limit.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Required if content_type is 'text'. Custom data that will be sent back to you via the messaging_postbacks webhook event. 1000 character limit.
        /// May be set to an empty string if image_url is set.
        /// Type must be string or number.
        /// </summary>
        [JsonProperty("payload")]
        public dynamic Payload { get; set; }

        /// <summary>
        /// Optional. URL of image to display on the quick reply button for text quick replies. Image should be a minimum of 24px x 24px. Larger images will be automatically cropped and resized.
        /// Required if title is an empty string.
        /// </summary>
        [JsonProperty("image_url")]
        public string ImagemUrl { get; set; }
    }
}
