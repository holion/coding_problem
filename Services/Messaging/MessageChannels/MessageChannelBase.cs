namespace coding_problem.Services.Messaging.MessageChannels;

public abstract class MessageChannelBase<T> : IMessageChannel
{
    public void SendMessage(string recipient, string message)
    {
        T? validReceipient = ValidateAndCreateReceipient(recipient);

        if (validReceipient is not null)
        {
            SendMessageInternal(validReceipient, message);
        }
        else
        {
            throw new ArgumentException("Invalid recipient");
        }
    }

    protected abstract void SendMessageInternal(T recipient, string message);

    protected abstract T? ValidateAndCreateReceipient(string recipient);
}