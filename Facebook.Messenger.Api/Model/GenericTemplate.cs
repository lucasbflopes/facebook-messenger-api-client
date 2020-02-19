using Newtonsoft.Json;
using System.Collections.Generic;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
    /// The generic template allows you to send a structured message that includes an image, text and buttons.
    /// A generic template with multiple templates described in the elements array will send a horizontally scrollable carousel of items, each composed of an image, text and buttons.
    /// </summary>
    public class GenericTemplate
    {
        /// <summary>
        /// Type of template.
        /// </summary>
        [JsonProperty("template_type")]
        public string TemplateType => "generic";

        /// <summary>
        /// List of generic elements up to 10.
        /// </summary>
        [JsonProperty("elements")]
        public IEnumerable<GenericElement> Elements { get; set; }
    }
}