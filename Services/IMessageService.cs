namespace coding_problem.Services;

public interface IMessageService
{
    void SendMessage(ChannelType channelType, string recipient, string message);
}