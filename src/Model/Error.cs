using Newtonsoft.Json;

namespace SendApi.Model
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("error_subcode")]
        public long ErrorSubcode { get; set; }

        [JsonProperty("fbtrace_id")]
        public string TraceId { get; set; }
    }
}
