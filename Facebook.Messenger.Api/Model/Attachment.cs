using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    public class Attachment
    {
        /// <summary>
        /// Type of attachment, may be image, audio, video, file or template. For assets, max file size is 25MB.
        /// </summary>
        [JsonProperty("type")]
        public AttachmentType Type { get; set; }

        /// <summary>
        /// Payload of attachment.
        /// </summary>
        [JsonProperty("payload")]
        public dynamic Payload { get; set; }
    }
}