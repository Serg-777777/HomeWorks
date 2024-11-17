
using WebApp_DEBUG.Logic.Middlewares;

public static class MonitorMiddlewareExt
	{
	public static IApplicationBuilder UseMonitorRequest(this IApplicationBuilder webApp)
	{
		webApp.UseMiddleware<MonitorRequestMiddleware>();
		return webApp;
	}
}

