

namespace WebApp_DEBUG.Logic.Middlewares
{
  
    public class MonitorRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public MonitorRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context, ILogger<MonitorRequestMiddleware> logger)
        {
			logger.LogError($"===MonitorMiddleware: {context.Request.Path}");
			return _next(context);
        }

	}
    
}
