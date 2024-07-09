namespace coding_problem.Services.Messaging;

public interface IMessageService
{
    SendMessageResponse SendMessage(ChannelType channelType, string recipient, string message);
}