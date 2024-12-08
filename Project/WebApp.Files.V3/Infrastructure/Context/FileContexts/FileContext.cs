
using Domain.Models.Files;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.FilesContexts;

public class FileContext:DbContext
{
    public DbSet<FileModel> FilesLibrary { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FilesDB.db"); // из конфиг
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilesContextConfig());
    }
}
