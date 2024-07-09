namespace coding_problem.Services.Messaging;

public interface IMessageService
{
    void SendMessage(ChannelType channelType, string recipient, string message);
}