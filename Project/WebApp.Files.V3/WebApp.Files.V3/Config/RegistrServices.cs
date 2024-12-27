using Application.AppServices.FilesServices;
using Domain.Models.Files;
using Infrastructure.Context.FilesContexts;
using Infrastructure.Repositories.FilesRepos;
using Microsoft.EntityFrameworkCore;
using Presentation.Mapping.MappingProfiles;

namespace Presentation.Config;

public static class RegistrServices
{
    public static IServiceCollection AddRegistrServices(this IServiceCollection serviceProvider)
    {
        serviceProvider

            .AddScoped<IFileRepository, FileRepos>()
            .AddScoped<IFileLoader<FileModel>, FileLoaderRepos>()
            .AddScoped<FileService>()
            .AddAutoMapper(typeof(FileMapperProfile))
            .AddLogging(p => p.AddConsole())
            .AddDbContext<FileContext>();// из конфиг;
        return serviceProvider;
    }
}
