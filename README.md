# How to install

`dotnet add package SendApiClient --version 1.0.0`

# How to create api wrapper instance
Without configuration
```c#
var pageAccessToken = ".....";
var client = new SendApiClient(pageAccessToken);
```
With configuration
```c#
var pageAccessToken = ".....";
var client = new SendApiClient(
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
var messageId = await client.SendTextMessageAsync(recipientId, "hello from the other side!");
```
Send action
```c#
await client.SendActionAsync(recipientId, SenderAction.TypingOn);
```
Send quick replies
```c#
var messageId = await client.SendQuickRepliesAsync(
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
var messageId = await client.SendAudioAsync(recipientId, "https://<where-your-audio-is-hosted>");
```
Send image
```c#
var messageId = await client.SendImageAsync(recipientId, "https://<where-your-image-is-hosted>");
```
Send video
```c#
var messageId = await client.SendVideoAsync(recipientId, "https://<where-your-video-is-hosted>");
```
Send file
```c#
var messageId = await client.SendFileAsync(recipientId, "https://<where-your-file-is-hosted>");
```
Send buttons
```c#
var messageId = await client.SendButtonsAsync(
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
var messageId = await client.SendGenericElementsAsync(
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
  return await client.SendTextMessageAsync(recipientId, "this call will fail for some reason :(");
}
catch (SendApiClientHttpException ex) when (ex.Error == null)
{
  // Call failed for some reason without obtaining response from facebook (e.g. timeout, network problems, etc)
  Console.WriteLine(ex.Message);
  Console.WriteLine(ex.InnerException);
    
  throw;
}
catch (SendApiClientHttpException ex)
{
  // See: https://developers.facebook.com/docs/messenger-platform/reference/send-api/error-codes
  Console.WriteLine(ex.Error.Code);
  Console.WriteLine(ex.Error.TraceId);
  Console.WriteLine(ex.Error.Message);
  
  throw;
}
```

