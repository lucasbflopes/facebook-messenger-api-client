using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Api.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AttachmentType
    {
        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "template")]
        Template
    }
}
