namespace coding_problem.Services.MessageChannels;

public interface IMessageChannel
{
    void SendMessage(string recipient, string message);
}