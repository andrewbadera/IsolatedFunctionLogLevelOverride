using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace IsolatedFunctionLogLevelOverride
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            _logger.LogCritical("critical message");
            _logger.LogDebug("debug message");
            _logger.LogError("error message");
            _logger.LogInformation("info message");
            _logger.LogTrace("trace message");
            _logger.LogWarning("warning message");

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
