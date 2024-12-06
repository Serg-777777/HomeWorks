
using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


  
namespace Infrastructure.Contexts.UserContexts.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.OwnsOne(p => p.UserRole);
            builder
                .HasOne(p => p.UserProfile)
                .WithOne(p => p.UserModel)
                .HasForeignKey<UserProfileModel>(p => p.UserModelId)
                .OnDelete(DeleteBehavior.Cascade);
          
            builder
                .HasOne(p=>p.UserSetting)
                .WithOne(p=>p.UserModel)
                .HasForeignKey<UserSettingModel>(p => p.UserModelId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasAlternateKey(p => p.Login);
        }
    }
}
