using Newtonsoft.Json;

namespace SendApi.Model
{
    public class AttachmentUrlPayload
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("is_reusable")]
        public bool IsReusable { get; set; }
    }
}
