

using Domain.Models.UserModels;
using Infrastructure.Contexts.UserContexts.Configs;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Contexts.UserContexts;

public class UserContext: DbContext
{
   public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<UserProfileModel> UserProfiles { get; set; } = null!;
    public DbSet<UserSettingModel> UserSettings { get; set; } = null!;

    public UserContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=UsersDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new UserContextConfig());
        modelBuilder.ApplyConfiguration(new UserProfileConfig());
        modelBuilder.ApplyConfiguration(new UserSettingsConfig());
    }
}
