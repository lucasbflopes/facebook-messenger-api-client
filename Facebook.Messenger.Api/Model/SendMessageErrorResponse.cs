using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    public class SendMessageErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}