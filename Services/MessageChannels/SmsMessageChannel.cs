using Microsoft.Extensions.Logging;

namespace coding_problem.Services.MessageChannels;

public class SmsMessageChannel : IMessageChannel
{
    private readonly ILogger<SmsMessageChannel> _logger;
    
    public SmsMessageChannel(ILogger<SmsMessageChannel> logger)
    {
        _logger = logger;
    }

    public void SendMessage(string recipient, string message)
    {
        _logger.LogInformation($"Sending SMS to {recipient}: {message}");
    }
}