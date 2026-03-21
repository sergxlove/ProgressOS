using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Configurations
{
    public class NotesConfiguration : IEntityTypeConfiguration<NotesEntity>
    {
        public void Configure(EntityTypeBuilder<NotesEntity> builder)
        {
            builder.ToTable("notes");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title)
                .IsRequired();
            builder.Property(a => a.Description)
                .IsRequired();
            builder.Property(a => a.DateCreate)
                .IsRequired();
            builder.Property(a => a.DateUpdate)
                .IsRequired();
        }
    }
}
