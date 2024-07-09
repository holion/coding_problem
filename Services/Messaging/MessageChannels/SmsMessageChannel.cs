using Microsoft.Extensions.Logging;

namespace coding_problem.Services.Messaging.MessageChannels;

public class SmsMessageChannel(ILogger<SmsMessageChannel> logger) : IMessageChannel
{
    public void SendMessage(string recipient, string message)
    {
        logger.LogInformation($"Sending SMS to {recipient}: {message}");
    }
}