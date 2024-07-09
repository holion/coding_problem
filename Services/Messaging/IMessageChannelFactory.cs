using coding_problem.Services.Messaging.MessageChannels;

namespace coding_problem.Services.Messaging;

public interface IMessageChannelFactory
{
    IMessageChannel Create(ChannelType channelType);
}