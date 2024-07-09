using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using coding_problem.Services.Messaging;

namespace coding_problem
{
    public class SendMessageHttpFn
    {
        private readonly ILogger<SendMessageHttpFn> _logger;
        private readonly IMessageService _messagingService;

        public SendMessageHttpFn(ILogger<SendMessageHttpFn> logger,
            IMessageService messageService)
        {
            _logger = logger;
            _messagingService = messageService;
        }

        [Function("SendMessage")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

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

            try
            {
                _messagingService.SendMessage(channelType, recipient, message);
                return new OkObjectResult($"Message sent via {channelType} to {recipient}: {message}");
            }
            catch (NotImplementedException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
