using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nickname)
                .IsRequired();
        }
    }
}
