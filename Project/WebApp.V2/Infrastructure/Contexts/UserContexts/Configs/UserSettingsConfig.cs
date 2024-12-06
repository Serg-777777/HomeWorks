
using Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Contexts.UserContexts.Configs
{
    internal class UserSettingsConfig : IEntityTypeConfiguration<UserSettingModel>
    {
        public void Configure(EntityTypeBuilder<UserSettingModel> builder)
        {

        }
    }
}
