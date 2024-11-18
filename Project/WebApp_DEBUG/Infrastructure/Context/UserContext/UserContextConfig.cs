using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp_DEBUG.Domain.Model.UserModel;

namespace WebApp_DEBUG.Infrastructure.Context.UserContext
{
    class UserContextConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> bild)
        {
            bild.ComplexProperty(p => p.UserRole).IsRequired();
            bild.UseTpcMappingStrategy();
            bild.HasAlternateKey(p => p.Login); 
        }
    }
}
