﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SendApi.Model
{
    /// <summary>
    /// The messaging type of the message being sent.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessagingType
    {
        /// <summary>
        /// Message is in response to a received message. This includes promotional and non-promotional messages sent inside the 24-hour standard messaging window or under the 24+1 policy. For example, use this tag to respond if a person asks for a reservation confirmation or an status update.
        /// </summary>
        [EnumMember(Value = "RESPONSE")]
        Response,

        /// <summary>
        /// Message is being sent proactively and is not in response to a received message. This includes promotional and non-promotional messages sent inside the the 24-hour standard messaging window or under the 24+1 policy.
        /// </summary>
        [EnumMember(Value = "UPDATE")]
        Update,


        /// <summary>
        /// Message is non-promotional and is being sent outside the 24-hour standard messaging window with a message tag. The message must match the allowed use case for the tag.
        /// </summary>
        [EnumMember(Value = "MESSAGE_TAG")]
        MessageTag
    }
}
