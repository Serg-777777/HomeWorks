
using Application.AppServices.FilesServices;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.FileProviders;

namespace Presentation.Config;

public static class RegistrServices
{
    public static IServiceCollection AddRegistrServices(this IServiceCollection serviceProvider)
    {
        serviceProvider
            .AddScoped<ILoader<IFormFile, IFileInfo>, FilesLoader>()
            .AddScoped<IFileService, FileService>();
        return serviceProvider;
    }
}
