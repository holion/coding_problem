namespace coding_problem.Services.Messaging.MessageChannels;

public interface IMessageChannel
{
    void SendMessage(string recipient, string message);
}