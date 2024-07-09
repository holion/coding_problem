using coding_problem.Services.MessageChannels;

namespace coding_problem.Services;

public interface IMessageChannelFactory
{
    IMessageChannel Create(ChannelType channelType);
}