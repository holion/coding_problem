using Microsoft.Extensions.Logging;

namespace coding_problem.Services.Messaging.MessageChannels;

public record PhoneNumber(string Value);

public class SmsMessageChannel(ILogger<SmsMessageChannel> logger) : MessageChannelBase<PhoneNumber>
{
    protected override PhoneNumber? ValidateAndCreateReceipient(string recipient)
    {
        if (recipient.All(char.IsDigit))
        {
            return new PhoneNumber(recipient);
        }

        return null;
    }

    protected override void SendMessageInternal(PhoneNumber recipient, string message)
    {
        logger.LogInformation($"Sending SMS to {recipient.Value}: {message}");
    }
}