using WebApp_DEBUG.Logic.Services;

static class HostedRegistration
{
	public static IServiceCollection AddHostedServices(this IServiceCollection services)
	{
		services
			.AddHostedService<HostedSrevices>()
			.AddHostedService<BackgroundHosted>();

		return services;
	}
}
