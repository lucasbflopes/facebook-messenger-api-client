using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SendApi.Model
{
    public class GenericElement
    {
        /// <summary>
        /// The title to display in the template. 80 character limit.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Optional. The subtitle to display in the template. 80 character limit.
        /// </summary>
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        /// <summary>
        /// Optional. The URL of the image to display in the template.
        /// </summary>
        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// Optional. An array of buttons to append to the template. A maximum of 3 buttons per element is supported.
        /// </summary>
        [JsonProperty("buttons")]
        public IEnumerable<Button> Buttons { get; set; }
    }
}
