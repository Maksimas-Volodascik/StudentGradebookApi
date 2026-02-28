using System.Diagnostics;

namespace StudentGradebookApi.Middleware

{
    public class LoggingMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            Guid correlationId = Guid.NewGuid();

            _logger.LogInformation("---------------------------");
            
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} from {context.Connection.RemoteIpAddress?.ToString()} User-Agent: {context.Request.Headers.UserAgent.ToString()} CorrelationId: {correlationId.ToString()}");
            
            await _next(context); //Call next middleware
            stopwatch.Stop();

            _logger.LogInformation($"Response: {context.Request.Method} {context.Request.Path} Status: {context.Response.StatusCode} Duration: {stopwatch.ElapsedMilliseconds}ms CorrelationId: {correlationId.ToString()}");
            
            _logger.LogInformation("---------------------------");
        }
    }
}
