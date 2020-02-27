using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Messenger.Api.Model;

namespace Facebook.Messenger.Api
{
    public interface IFacebookService
    {
        /// <summary>
        /// Sends text message to recipient.
        /// </summary>
        /// <param name="recipientId">Recipient of text message</param>
        /// <param name="message">Message to be sent</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendTextMessageAsync(string recipientId, string message);

        /// <summary>
        /// Sends action (e.g. typing bubble) to recipient.
        /// </summary>
        /// <param name="recipientId">Recipient of action</param>
        /// <param name="action">Action to be sent</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        Task SendActionAsync(string recipientId, SenderAction action);

        /// <summary>
        /// Sends video to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages#sending_attachments"/>
        /// <param name="recipientId">Recipient of attachment</param>
        /// <param name="url">Url where file is hosted</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendVideoAsync(string recipientId, string url);

        /// <summary>
        /// Sends image to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages#sending_attachments"/>
        /// <param name="recipientId">Recipient of attachment</param>
        /// <param name="url">Url where file is hosted</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendImageAsync(string recipientId, string url);

        /// <summary>
        /// Sends audio to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages#sending_attachments"/>
        /// <param name="recipientId">Recipient of attachment</param>
        /// <param name="url">Url where file is hosted</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendAudioAsync(string recipientId, string url);

        /// <summary>
        /// Sends file to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages#sending_attachments"/>
        /// <param name="recipientId">Recipient of attachment</param>
        /// <param name="url">Url where file is hosted</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendFileAsync(string recipientId, string url);

        /// <summary>
        /// Sends quickreplies (up to 13 buttons) to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages/quick-replies"/>
        /// <param name="recipientId">Recipient of message</param>
        /// <param name="message">Text to show above quick reply buttons</param>
        /// <param name="quickReplies">List of quick replies (up to 13)</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendQuickRepliesAsync(string recipientId, string message, IEnumerable<QuickReply> quickReplies);

        /// <summary>
        /// Sends buttons (up to 3) to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages/template/button"/>
        /// <param name="recipientId">Recipient of message</param>
        /// <param name="message">Text to show above buttons</param>
        /// <param name="buttons">List of buttons (up to 3)</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendButtonsAsync(string recipientId, string message, IEnumerable<Button> buttons);

        /// <summary>
        /// Sends generic template (up to 10) to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/send-messages/template/generic"/>
        /// <param name="recipientId">Recipient of message</param>
        /// <param name="elements">List of generic elements to display</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendGenericElementsAsync(string recipientId, IEnumerable<GenericElement> elements);

        /// <summary>
        /// Sends custom message to recipient.
        /// </summary>
        /// <seealso cref="https://developers.facebook.com/docs/messenger-platform/reference/send-api/#message"/>
        /// <param name="messageRequest">Message request to be sent</param>
        /// <exception cref="FacebookServiceHttpException">Call failed</exception>
        /// <returns>Message id</returns>
        Task<string> SendCustomMessageAsync(SendMessageRequest messageRequest);
    }
}