using Application.ServicesViews.UserServicesApps;
using Infrastructure.Contexts.UserContexts;
using Infrastructure.Repositories.UserRepos;

namespace Presentation.Configs
{
    public static class UserServiceRegistration
    {
        public static IServiceCollection AddUsersServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<UserService>()
            .AddDbContext<UserContext>();
            return services;
        }
    }
}
