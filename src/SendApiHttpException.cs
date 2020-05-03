using SendApi.Model;
using System;

namespace SendApi
{
    /// <summary>
	/// An exception that is thrown when an HTTP call to the facebook api fails, including when the response
	/// indicates an unsuccessful HTTP status code.
	/// </summary>
    public class SendApiHttpException : Exception
    {
        /// <summary>
        /// Error object returned by the facebook api.
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/reference/send-api/error-codes"/>
        /// </summary>
        public Error Error { get; }

        public SendApiHttpException(
            Error error,
            string message) : base(message)
        {
            Error = error;
        }

        public SendApiHttpException(
            Error error,
            string message,
            Exception innerException) : base(message, innerException)
        {
            Error = error;
        }
    }
}
