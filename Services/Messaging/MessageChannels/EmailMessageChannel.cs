using Microsoft.Extensions.Logging;

namespace coding_problem.Services.Messaging.MessageChannels;

public class EmailMessageChannel(ILogger<EmailMessageChannel> logger) : IMessageChannel
{
    public void SendMessage(string recipient, string message)
    {
        logger.LogInformation($"Sending email to {recipient}: {message}");
    }
}