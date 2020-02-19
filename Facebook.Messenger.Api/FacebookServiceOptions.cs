﻿using System;

namespace Facebook.Messenger.Api
{
    public class FacebookServiceOptions
    {
        /// <summary>
        /// Api version. Example: v6.0
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Timeout for all requests made to the facebook api.
        /// </summary>
        public TimeSpan Timeout { get; set; }
    }
}