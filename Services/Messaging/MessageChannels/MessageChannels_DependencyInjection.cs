using Microsoft.Extensions.DependencyInjection;

namespace coding_problem.Services.Messaging.MessageChannels;

public static class MessageChannel_DependencyInjection
{
    public static IServiceCollection AddMessageChannels(this IServiceCollection services)
    {
        services.AddSingleton<SmsMessageChannel>();
        services.AddSingleton<EmailMessageChannel>();
        return services;
    }
}