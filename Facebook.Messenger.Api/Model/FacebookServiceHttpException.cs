using System;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
	/// An exception that is thrown when an HTTP call to the facebook api fails, including when the response
	/// indicates an unsuccessful HTTP status code.
	/// </summary>
    internal class FacebookServiceHttpException : Exception
    {
        /// <summary>
        /// Error object returned by the facebook api.
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/reference/send-api/error-codes"/>
        /// </summary>
        public Error Error { get; }

        public FacebookServiceHttpException(
            Error error,
            string message) : base(message)
        {
            Error = error;
        }

        public FacebookServiceHttpException(
            Error error,
            string message,
            Exception innerException) : base(message, innerException)
        {
            Error = error;
        }
    }
}