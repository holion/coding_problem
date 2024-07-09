namespace coding_problem.Services.Messaging;

public sealed class MessageService(IMessageChannelFactory messageChannelFactory) : IMessageService
{
    public SendMessageResponse SendMessage(ChannelType channelType, string recipient, string message)
    {
        var messageChannel = messageChannelFactory.Create(channelType);

        try
        {
            messageChannel.SendMessage(recipient, message);
            return new SendMessageResponse(true, null);
        }
        catch (ArgumentException ex)
        {
            return new SendMessageResponse(false, ex.Message);
        }
    }
}
