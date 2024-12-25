
using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Contexts.UserContexts;

public class UserContext: DbContext
{
   public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<UserProfileModel> Profiles { get; set; } = null!;
    public UserContext() 
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=UsersDatabase.db");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new UserProfileConfig());
    }
}
