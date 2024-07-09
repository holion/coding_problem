namespace coding_problem.Services.Messaging;

public sealed class MessageService(IMessageChannelFactory messageChannelFactory) : IMessageService
{
    public void SendMessage(ChannelType channelType, string recipient, string message)
    {
        var messageChannel = messageChannelFactory.Create(channelType);

        messageChannel.SendMessage(recipient, message);
    }
}
