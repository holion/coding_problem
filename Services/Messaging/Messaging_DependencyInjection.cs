using coding_problem.Services.Messaging.MessageChannels;
using Microsoft.Extensions.DependencyInjection;

namespace coding_problem.Services.Messaging;

public static class Messaging_DependencyInjection
{
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IMessageChannelFactory, MessageChannelFactory>();
        services.AddSingleton<IMessageService, MessageService>();
        services.AddMessageChannels();
        return services;
    }
}