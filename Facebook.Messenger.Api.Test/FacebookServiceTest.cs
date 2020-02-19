using FluentAssertions;
using Flurl.Http.Testing;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using AutoFixture;
using Facebook.Messenger.Api.Model;
using System.Net.Http;

namespace Facebook.Messenger.Api.Test
{
    public class FacebookServiceTest
    {
        private HttpTest _http;
        private string _accessKey;
        private FacebookService _service;
        private Fixture _fixture;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void Setup()
        {
            _http = new HttpTest();
            _accessKey = _fixture.Create<string>();
            _service = new FacebookService(_accessKey);
        }

        [TearDown]
        public void Teardown()
        {
            _http.Dispose();
        }

        [Test]
        public async Task ShouldBuildRequestToSendTextMessageCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendTextMessageAsync("123", "Hello!");

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        text = "Hello!"
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendActionCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendActionAsync("123", SenderAction.TypingOn);

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    sender_action = "typing_on"
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendQuickRepliesCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendQuickRepliesAsync(
                "123",
                "message",
                new[]
                {
                    QuickReply.Text("foo", "bar", "https://www.foo.com"),
                    QuickReply.UserEmail(),
                    QuickReply.UserPhoneNumber()
                }
            );

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        text = "message",
                        quick_replies = new dynamic[]
                        {
                            new
                            {
                                content_type = "text",
                                title = "foo",
                                payload = "bar",
                                image_url = "https://www.foo.com"
                            },
                            new
                            {
                                content_type = "user_email"
                            },
                            new
                            {
                                content_type = "user_phone_number"
                            }
                        }
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendImageCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendImageAsync("123", "image-url");

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        attachment = new
                        {
                            type = "image",
                            payload = new
                            {
                                url = "image-url",
                                is_reusable = false
                            }
                        }
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendVideoCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendVideoAsync("123", "video-url");

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        attachment = new
                        {
                            type = "video",
                            payload = new
                            {
                                url = "video-url",
                                is_reusable = false
                            }
                        }
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendAudioCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendAudioAsync("123", "audio-url");

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        attachment = new
                        {
                            type = "audio",
                            payload = new
                            {
                                url = "audio-url",
                                is_reusable = false
                            }
                        }
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendFileCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendFileAsync("123", "file-url");

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        attachment = new
                        {
                            type = "file",
                            payload = new
                            {
                                url = "file-url",
                                is_reusable = false
                            }
                        }
                    }
                });
        }

        [Test]
        public async Task ShouldBuildRequestToSendButtonsCorrectly()
        {
            _http.RespondWithJson(_fixture.Create<SendMessageResponse>());

            await _service.SendButtonsAsync(
                "123",
                "message",
                new[]
                {
                    Button.Postback("title", "payload"),
                    Button.WebUrl("title2", "url2")
                }
            );

            _http
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    messaging_type = "RESPONSE",
                    recipient = new
                    {
                        id = "123"
                    },
                    message = new
                    {
                        attachment = new
                        {
                            type = "template",
                            payload = new
                            {
                                template_type = "button",
                                text = "message",
                                buttons = new dynamic[]
                                {
                                    new
                                    {
                                        type = "postback",
                                        title = "title",
                                        payload = "payload"
                                    },
                                    new
                                    {
                                        type = "web_url",
                                        url = "url2",
                                        title = "title2",
                                    }
                                }
                            }
                        }
                    }
                });
        }

        [Test]
        public void ShouldThrowExceptionWithoutErrorObjectWhenApiCallFailsAndRequestIsNotCompleted()
        {
            _http.SimulateTimeout();

            Func<Task> action = async () => await _service.SendTextMessageAsync("123", "hello");

            action
                .Should()
                .Throw<FacebookServiceHttpException>()
                .Where(ex => ex.Error == null);
        }

        [Test]
        public void ShouldThrowExceptionWithErrorObjectWhenApiCallFailsAndRequestDoesComplete()
        {
            var error = _fixture.Create<SendMessageErrorResponse>();
            _http.RespondWithJson(error, status: 400);

            Func<Task> action = async () => await _service.SendTextMessageAsync("123", "hello");

            action
                .Should()
                .Throw<FacebookServiceHttpException>()
                .Which.Error.Should().BeEquivalentTo(error.Error);
        }
    }
}