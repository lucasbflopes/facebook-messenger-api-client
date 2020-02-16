using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Facebook.Messenger.Api.Model;
using System;

namespace Facebook.Messenger.Api
{
    public partial class FacebookService : IFacebookService
    {
        private const string _url = "https://graph.facebook.com";
        private readonly string _pageAccessToken;
        private readonly FacebookServiceOptions _config;

        public FacebookService(string pageAccessToken): this(pageAccessToken, _ => { }){}

        public FacebookService(string pageAccessToken, Action<FacebookServiceOptions> options)
        {
            _pageAccessToken = pageAccessToken;
            _config = new FacebookServiceOptions
            {
                ApiVersion = "v6.0",
                Timeout = TimeSpan.FromSeconds(1)
            };

            options(_config);
        }

        public async Task<string> SendActionAsync(Recipient recipient, SenderAction action)
        {
            try
            {

                var response = await MakeApiCall(
                    new SendMessageRequest
                    {
                        MessagingType = MessagingType.Response,
                        Recipient = recipient,
                        SenderAction = action
                    }
                );

                return response.MessageId;
            }
            catch (FlurlHttpException ex)
            {
                throw new FacebookServiceHttpException(ex.Call.Response.StatusCode, ex.Message, ex.InnerException);
            }
        }

        public async Task<string> SendAttachmentAsync(Recipient recipient, AttachmentType type, string url)
        {
            try
            {
                var response = await MakeApiCall(
                    new SendMessageRequest
                    {
                        MessagingType = MessagingType.Response,
                        Recipient = recipient,
                        Message = new Message
                        {
                            Attachment = new Attachment
                            {
                                Type = type,
                                Payload = new AttachmentUrlPayload
                                {
                                    Url = url,
                                    IsReusable = false
                                }
                            }
                        }
                    }
                );

                return response.MessageId;
            }
            catch (FlurlHttpException ex)
            {
                throw new FacebookServiceHttpException(ex.Call.Response.StatusCode, ex.Message, ex.InnerException);
            }
        }

        public async Task<string> SendMessageAsync(Recipient recipient, string message)
        {
            try
            {
                var response = await MakeApiCall(
                    new SendMessageRequest
                    {
                        MessagingType = MessagingType.Response,
                        Recipient = recipient,
                        Message = new Message
                        {
                            Text = message
                        }
                    }
                );

                return response.MessageId;
            }
            catch (FlurlHttpException ex)
            {
                throw new FacebookServiceHttpException(ex.Call.Response.StatusCode, ex.Message, ex.InnerException);
            }
        }

        private Task<SendMessageResponse> MakeApiCall<TPayload>(TPayload payload)
        {
            return _url
                .AppendPathSegments(_config.ApiVersion, "me", "messages")
                .SetQueryParam("access_token", _pageAccessToken)
                .WithTimeout(_config.Timeout)
                .PostJsonAsync(payload)
                .ReceiveJson<SendMessageResponse>();
        }
    }
}
