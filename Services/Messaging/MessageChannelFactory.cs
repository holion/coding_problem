using coding_problem.Services.Messaging.MessageChannels;
using Microsoft.Extensions.DependencyInjection;

namespace coding_problem.Services.Messaging;

public sealed class MessageChannelFactory(IServiceProvider serviceProvider) : IMessageChannelFactory
{
    public IMessageChannel Create(ChannelType channelType)
    {
        return channelType switch
        {
            ChannelType.Sms => serviceProvider.GetRequiredService<SmsMessageChannel>(),
            ChannelType.Email => serviceProvider.GetRequiredService<EmailMessageChannel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(channelType), channelType, null)
        };
    }
}
