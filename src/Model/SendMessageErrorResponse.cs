using Newtonsoft.Json;

namespace SendApi.Model
{
    public class SendMessageErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
