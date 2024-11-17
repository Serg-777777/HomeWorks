using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp_DEBUG.Domain.Model.UserModel
{
    class UserContextConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> bild)
        {
            bild.ComplexProperty(p => p.UserRole).IsRequired();
            bild.UseTpcMappingStrategy();
          //  bild.HasAlternateKey(p => p.Login);
        }
    }
}
