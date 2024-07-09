using Microsoft.Extensions.Logging;

namespace coding_problem.Services.Messaging.MessageChannels;

public record Email(string Value);

public class EmailMessageChannel(ILogger<EmailMessageChannel> logger) : MessageChannelBase<Email>
{
    protected override Email? ValidateAndCreateReceipient(string recipient)
    {
        if (recipient.Contains("@"))
        {
            return new Email(recipient);
        }

        return null;
    }

    protected override void SendMessageInternal(Email recipient, string message)
    {
        logger.LogInformation($"Sending email to {recipient.Value}: {message}");
    }
}