using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coding_problem.Services.Messaging;

namespace coding_problem
{
    public class SendMessageHttpFn(
        ILogger<SendMessageHttpFn> logger,
        IMessageService messageService)
    {
        [Function("SendMessage")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            if (!Enum.TryParse<ChannelType>(req.Query["channel"], true, out var channelType))
            {
                return new BadRequestObjectResult("Invalid channel type.");
            }

            string? recipient = req.Query["recipient"];
            string? message = req.Query["message"];

            if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(message))
            {
                return new BadRequestObjectResult("Please provide recipient and message.");
            }

            var response = messageService.SendMessage(channelType, recipient, message);
            
            if (response.IsSuccess)
            {
                return new OkObjectResult($"Message sent via {channelType} to {recipient}: {message}");
            }
            else
            {
                return new BadRequestObjectResult(response.ErrorMessage);
            }
        }
    }
}
