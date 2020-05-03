using Newtonsoft.Json;
using System.Collections.Generic;

namespace SendApi.Model
{
    /// <summary>
    /// The button template sends a text message with up to three attached buttons.
    /// This template is useful for offering the message recipient options to choose from, such as pre-determined responses to a question, or actions to take.
    /// </summary>
    public class ButtonTemplate
    {
        /// <summary>
        /// Type of template.
        /// </summary>
        [JsonProperty("template_type")]
        public string TemplateType => "button";

        /// <summary>
        /// UTF-8-encoded text of up to 640 characters. Text will appear above the buttons.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Set of 1-3 buttons that appear as call-to-actions.
        /// </summary>
        [JsonProperty("buttons")]
        public IEnumerable<Button> Buttons { get; set; }
    }
}
