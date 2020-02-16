using System.Threading.Tasks;
using Facebook.Messenger.Api.Model;

namespace Facebook.Messenger.Api
{
    public partial interface IFacebookService
    {
        /// <summary>
        /// Sends message to recipient.
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendMessageAsync(Recipient recipient, string message);

        /// <summary>
        /// Sends action to recipient.
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendActionAsync(Recipient recipient, SenderAction action);

        /// <summary>
        /// Sends media to recipient.
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendAttachmentAsync(Recipient recipient, AttachmentType type, string url);
    }
}
