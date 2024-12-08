using Application.AppServices.FilesServices;
using Domain.Models.Files;
using Infrastructure.Context.FilesContexts;
using Infrastructure.Repositories.FilesRepos;
using Microsoft.EntityFrameworkCore;
using Presentation.Mapping.MappingProfiles;

namespace Presentation.Config;

public static class RegistrServices
{
    public static IServiceCollection AddRegistrServices(this IServiceCollection serviceProvider, IConfiguration configuration)
    {
        serviceProvider
            .AddDbContext<FileContext>(p => p.UseSqlite("Data Source=FilesDB.db"))// из конфиг;
            .AddTransient<IFileRepository, FileRepos>()
            .AddTransient<IFileLoader<FileModel>, FileLoaderRepos>()
            .AddTransient<FileService>()
            .AddAutoMapper(typeof(FileMapperProfile))
            .AddLogging(p => p.AddConsole());
        
        return serviceProvider;
    }
}
