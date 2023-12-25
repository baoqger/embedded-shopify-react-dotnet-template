using backend.Services;

namespace backend.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)

        {
            _logger.LogDebug($"Debug JWT : {context.Request.Path}, {context.Request.Headers.Authorization}");
            await _next(context);
        }
    }
}
