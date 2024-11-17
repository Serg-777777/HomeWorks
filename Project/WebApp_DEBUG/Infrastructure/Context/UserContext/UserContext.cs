
using Microsoft.EntityFrameworkCore;
using WebApp_DEBUG.Domain.Model.UserModel;

namespace WebApp_DEBUG.Infrastructure.Context.UserContext
{
    class UserContext : DbContext
    {
        // internal можно?
        public DbSet<User> Users { set; get; } = null!;
        public DbSet<UserSetting> UserSettings { set; get; } = null!;
        public DbSet<UserInfo> UserInfo { set; get; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlite($"Data Source=Domain/DBase/dbTest.db"); //JSON конфиг
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserContextConfig());
        }

    }

}
