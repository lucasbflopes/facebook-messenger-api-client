using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Facebook.Messenger.Api.Model;
using System;
using System.Collections.Generic;

namespace Facebook.Messenger.Api
{
    public class FacebookService : IFacebookService
    {
        private const string _url = "https://graph.facebook.com";
        private const string _defaultApiVersion = "v6.0";
        private readonly string _pageAccessToken;
        private readonly FacebookServiceOptions _config;

        public FacebookService(string pageAccessToken) : this(pageAccessToken, _ => { })
        {
        }

        public FacebookService(string pageAccessToken, Action<FacebookServiceOptions> options)
        {
            _pageAccessToken = pageAccessToken;
            _config = new FacebookServiceOptions
            {
                ApiVersion = _defaultApiVersion,
                Timeout = TimeSpan.FromSeconds(10)
            };

            options?.Invoke(_config);
        }

        public Task<string> SendTextMessageAsync(string recipientId, string message)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    MessagingType = MessagingType.Response,
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    Message = new Message
                    {
                        Text = message
                    }
                }
            );
        }

        public Task SendActionAsync(string recipientId, SenderAction action)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    SenderAction = action
                }
            );
        }

        public Task<string> SendButtonsAsync(string recipientId, string message, IEnumerable<Button> buttons)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    MessagingType = MessagingType.Response,
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    Message = new Message
                    {
                        Attachment = new Attachment
                        {
                            Type = AttachmentType.Template,
                            Payload = new ButtonTemplate
                            {
                                Text = message,
                                Buttons = buttons
                            }
                        }
                    }
                }
            );
        }

        public Task<string> SendGenericElementsAsync(string recipientId, IEnumerable<GenericElement> elements)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    MessagingType = MessagingType.Response,
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    Message = new Message
                    {
                        Attachment = new Attachment
                        {
                            Type = AttachmentType.Template,
                            Payload = new GenericTemplate
                            {
                                Elements = elements
                            }
                        }
                    }
                }
            );
        }

        public Task<string> SendQuickRepliesAsync(string recipientId, string message, IEnumerable<QuickReply> quickReplies)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    MessagingType = MessagingType.Response,
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    Message = new Message
                    {
                        Text = message,
                        QuickReplies = quickReplies
                    }
                }
            );
        }

        public Task<string> SendAudioAsync(string recipientId, string url)
        {
            return SendAttachmentAsync(recipientId, AttachmentType.Audio, url);
        }

        public Task<string> SendFileAsync(string recipientId, string url)
        {
            return SendAttachmentAsync(recipientId, AttachmentType.File, url);
        }

        public Task<string> SendImageAsync(string recipientId, string url)
        {
            return SendAttachmentAsync(recipientId, AttachmentType.Image, url);
        }

        public Task<string> SendVideoAsync(string recipientId, string url)
        {
            return SendAttachmentAsync(recipientId, AttachmentType.Video, url);
        }

        private Task<string> SendAttachmentAsync(string recipientId, AttachmentType type, string url)
        {
            return MakeApiCall(
                new SendMessageRequest
                {
                    MessagingType = MessagingType.Response,
                    Recipient = new Recipient
                    {
                        Id = recipientId
                    },
                    Message = new Message
                    {
                        Attachment = new Attachment
                        {
                            Type = type,
                            Payload = new AttachmentUrlPayload
                            {
                                Url = url
                            }
                        }
                    }
                }
            );
        }

        public Task<string> SendCustomMessageAsync(SendMessageRequest messageRequest)
        {
            return MakeApiCall(messageRequest);
        }

        private async Task<string> MakeApiCall(SendMessageRequest payload)
        {
            try
            {
                var response = await _url
                    .AppendPathSegments(_config.ApiVersion, "me", "messages")
                    .SetQueryParam("access_token", _pageAccessToken)
                    .WithTimeout(_config.Timeout)
                    .PostJsonAsync(payload)
                    .ReceiveJson<SendMessageResponse>();

                return response.MessageId;
            }
            catch (FlurlHttpException ex) when (ex.Call.Completed)
            {
                var errorResponse = await ex.GetResponseJsonAsync<SendMessageErrorResponse>();

                throw new FacebookServiceHttpException(errorResponse.Error, ex.Message);
            }
            catch (FlurlHttpException ex)
            {
                throw new FacebookServiceHttpException(null, ex.Message, ex.InnerException);
            }
        }
    }
}
