using Newtonsoft.Json;
using System;

namespace Facebook.Messenger.Api.Model
{
    public class QuickReply
    {
        /// <summary>
        /// The text quick reply allows you to ask a user for a pre-defined text option.
        /// </summary>
        /// <param name="title">The text to display on the quick reply button. 20 character limit.</param>
        /// <param name="payload">Custom data that will be sent back to you via the messaging_postbacks webhook event. 1000 character limit.</param>
        /// <param name="url">Optional URL of image to display on the quick reply button for text quick replies. Image should be a minimum of 24px x 24px. Larger images will be automatically cropped and resized.</param>
        public static QuickReply Text(string title, string payload, string url = null) =>
            new QuickReply(QuickReplyContentType.Text, title, payload, url);

        /// <summary>
        /// The user email quick reply allows you to ask a user for the phone number.
        /// </summary>
        public static QuickReply UserPhoneNumber() =>
            new QuickReply(QuickReplyContentType.UserPhoneNumber, null, null, null);

        /// <summary>
        /// The user email quick reply allows you to ask a user for the email.
        /// </summary>
        public static QuickReply UserEmail() =>
            new QuickReply(QuickReplyContentType.UserEmail, null, null, null);

        private QuickReply(QuickReplyContentType type, string title, string payload, string url)
        {
            if (type == QuickReplyContentType.Text && string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Text quick replies should not have a null or empty title", nameof(title));
            }

            if (type == QuickReplyContentType.Text && string.IsNullOrEmpty(payload))
            {
                throw new ArgumentException("Text quick replies should not have a null or empty payload", nameof(payload));
            }

            ContentType = type;
            Title = title;
            Payload = payload;
            ImageUrl = url;
        }

        /// <summary>
        /// Content type of quick reply.
        /// </summary>
        [JsonProperty("content_type")]
        public QuickReplyContentType ContentType { get; }

        /// <summary>
        /// Required if content_type is 'text'. The text to display on the quick reply button. 20 character limit.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// Required if content_type is 'text'. Custom data that will be sent back to you via the messaging_postbacks webhook event. 1000 character limit.
        /// May be set to an empty string if image_url is set.
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; }

        /// <summary>
        /// Optional. URL of image to display on the quick reply button for text quick replies. Image should be a minimum of 24px x 24px. Larger images will be automatically cropped and resized.
        /// Required if title is an empty string.
        /// </summary>
        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; }
    }
}