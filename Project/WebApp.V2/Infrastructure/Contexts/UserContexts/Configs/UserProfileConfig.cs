using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.UserContexts.Configs
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfileModel>
    {
        public void Configure(EntityTypeBuilder<UserProfileModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(p => p.UserModel)
                .WithOne(p => p.ProfileModel)
                .HasForeignKey<UserProfileModel>(p => p.UserModelId); 
        }
    }
}
