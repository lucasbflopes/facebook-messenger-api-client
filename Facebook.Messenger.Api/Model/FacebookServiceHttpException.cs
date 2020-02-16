using System;
using System.Net;

namespace Facebook.Messenger.Api.Model
{
    /// <summary>
	/// An exception that is thrown when an HTTP call to the facebook api fails, including when the response
	/// indicates an unsuccessful HTTP status code.
	/// </summary>
    internal class FacebookServiceHttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public FacebookServiceHttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public FacebookServiceHttpException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
