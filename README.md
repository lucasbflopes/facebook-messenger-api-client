# How to create api wrapper instance
Without configuration
```c#
var pageAccessToken = ".....";
var service = new FacebookService(pageAccessToken);
```
With configuration
```c#
var pageAccessToken = ".....";
var service = new FacebookService(
  pageAccessToken,
  config =>
  {
    config.ApiVersion = "v6.0";
    config.Timeout = Timespan.FromSeconds(1);
  }
);
```

# How to use
Send text message
```c#
var messageId = await service.SendTextMessageAsync(recipientId, "hello from the other side!");
```
Send action
```c#
await service.SendActionAsync(recipientId, SenderAction.TypingOn);
```
Send quick replies
```c#
var messageId = await service.SendQuickRepliesAsync(
  recipientId,
  "Choose one of the following:",
  new[]
  {
    QuickReply.Text("Option A", "payload option A"),
    QuickReply.UserEmail(),
    QuickReply.UserPhoneNumber()
  }
);
```
Send audio
```c#
var messageId = await service.SendAudioAsync(recipientId, "https://<where-your-audio-is-hosted>");
```
Send image
```c#
var messageId = await service.SendImageAsync(recipientId, "https://<where-your-image-is-hosted>");
```
Send video
```c#
var messageId = await service.SendVideoAsync(recipientId, "https://<where-your-video-is-hosted>");
```
Send file
```c#
var messageId = await service.SendFileAsync(recipientId, "https://<where-your-file-is-hosted>");
```
Send buttons
```c#
var messageId = await service.SendButtonsAsync(
  recipientId,
  "What do you want to do?",
  new[]
  {
    Button.Postback("I don't know.", "payload button"),
    Button.WebUrl("Go to google", "https://www.google.com")
  }
);
```
Send generic elements (more like cards and carousels)
```c#
var messageId = await service.SendGenericElementsAsync(
  recipientId,
  new[]
  {
    new GenericElement
    {
      Title = "title",
      Subtitle = "Subtitle",
      ImageUrl = "<url-of-image>"
    },
    new GenericElement
    {
      Title = "title",
      Subtitle = "Subtitle",
      ImageUrl = "<url-of-image>",
      Buttons = new[]
      {
        Button.WebUrl("Go to google", "https://www.google.com"),
        Button.WebUrl("Go to facebook", "https://www.facebook.com")
      }
    }
  }
);
```

# Error handling
```c#
try
{
  return await service.SendTextMessageAsync(recipientId, "this call will fail for some reason :(");
}
catch (FacebookServiceHttpException ex) when (ex.Error == null)
{
  // Call failed for some reason without obtaining response from facebook (e.g. timeout, network problems, etc)
  Console.WriteLine(ex.Message);
  Console.WriteLine(ex.InnerException);
    
  throw;
}
catch (FacebookServiceHttpException ex)
{
  // See: https://developers.facebook.com/docs/messenger-platform/reference/send-api/error-codes
  Console.WriteLine(ex.Error.Code);
  Console.WriteLine(ex.Error.TraceId);
  Console.WriteLine(ex.Error.Message);
  
  throw;
}
```

