
using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.UserContexts.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.OwnsOne(p => p.Role);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(p=>p.Login);
        }
    }
}
