using Microsoft.Extensions.Logging;

namespace coding_problem.Services.Messaging.MessageChannels;

public class EmailMessageChannel : IMessageChannel
{
    private readonly ILogger<EmailMessageChannel> _logger;

    public EmailMessageChannel(ILogger<EmailMessageChannel> logger)
    {
        _logger = logger;
    }

    public void SendMessage(string recipient, string message)
    {
        _logger.LogInformation($"Sending email to {recipient}: {message}");
    }
}