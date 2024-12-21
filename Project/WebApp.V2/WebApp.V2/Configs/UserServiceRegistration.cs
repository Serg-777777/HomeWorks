using Application.AppServices.UserAppServices;
using Application.ServicesViews.UserServicesApps;
using Domain.Models.UserModels;
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
            .AddScoped<IUserProfileRepository, UserProfileRepository>()
            .AddScoped<UserService>()
            .AddDbContext<UserContext>()
            .AddScoped<UserProfileService>();
            return services;
        }
    }
}
