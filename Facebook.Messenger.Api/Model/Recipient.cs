﻿using Newtonsoft.Json;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
    /// Description of the message recipient. All requests must include one of the properties to identify the recipient.
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Page Scoped User ID (PSID) of the message recipient. The user needs to have interacted with any of the Messenger entry points in order to opt-in into messaging with the Page. Note that Facebook Login integrations return user IDs are app-scoped and will not work with the Messenger platform.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Used for the checkbox plugin.
        /// </summary>
        [JsonProperty("user_ref")]
        public string UserRef { get; set; }

        /// <summary>
        /// Used for Private Replies to reference the visitor post to reply to.
        /// </summary>
        [JsonProperty("post_id")]
        public string PostId { get; set; }

        /// <summary>
        /// Used for Private Replies to reference the post comment to reply to.
        /// </summary>
        [JsonProperty("comment_id")]
        public string CommentId { get; set; }
    }
}
