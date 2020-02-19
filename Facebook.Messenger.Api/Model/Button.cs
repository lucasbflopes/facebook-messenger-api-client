using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    public class Button
    {
        /// <summary>
        /// The postback button sends a messaging_postbacks event to your webhook with the string set in the payload property.
        /// This allows you to take an arbitrary actions when the button is tapped
        /// </summary>
        /// <param name="title">Button title. 20 character limit.</param>
        /// <param name="payload">This data will be sent back to your webhook. 1000 character limit.</param>
        /// <returns>Postback button</returns>
        public static Button Postback(string title, string payload) => new Button(ButtonType.Postback, title, payload, null);

        /// <summary>
        /// The URL Button opens a web page in the Messenger webview.
        /// This allows you to enrich the conversation with a web-based experience, where you have the full development flexibility of the web.
        /// </summary>
        /// <param name="title">Button title. 20 character limit.</param>
        /// <param name="url">Url to open in webview</param>
        /// <returns>Weburl button</returns>
        public static Button WebUrl(string title, string url) => new Button(ButtonType.WebUrl, title, null, url);

        private Button(ButtonType type, string title, string payload, string url)
        {
            Type = type;
            Title = title;
            Payload = payload;
            Url = url;
        }

        /// <summary>
        /// Type of button
        /// </summary>
        [JsonProperty("type")]
        public ButtonType Type { get; }

        /// <summary>
        /// This URL is opened in a mobile browser when the button is tapped. Button type must be web_url.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; }

        /// <summary>
        /// Button title. 20 character limit.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; }

        /// <summary>
        /// This data will be sent back to your webhook. 1000 character limit. Button type must be postback
        /// </summary>
        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; }
    }
}