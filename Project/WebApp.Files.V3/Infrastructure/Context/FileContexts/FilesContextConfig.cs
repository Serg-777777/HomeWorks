using Domain.Models.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.FilesContexts
{
    internal class FilesContextConfig : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            builder.HasAlternateKey(p => p.Index_UserKey_FileName).HasName("IndexFiles");
            builder.HasIndex(p => p.Index_UserKey_FileName);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}