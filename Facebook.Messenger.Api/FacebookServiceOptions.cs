using System;

namespace Facebook.Messenger.Api
{
    public class FacebookServiceOptions
    {
        public string ApiVersion { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}
