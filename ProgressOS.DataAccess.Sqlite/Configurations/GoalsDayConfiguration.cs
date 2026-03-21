using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Configurations
{
    public class GoalsDayConfiguration : IEntityTypeConfiguration<GoalsDayEntity>
    {
        public void Configure(EntityTypeBuilder<GoalsDayEntity> builder)
        {
            builder.ToTable("goalsDay");
            builder.HasKey(a =>  a.Id);
            builder.Property(a => a.Name)
                .IsRequired();
            builder.Property(a => a.Description)
                .IsRequired();
            builder.Property(a => a.CurrentProgress)
                .IsRequired();
            builder.Property(a => a.TotalProgress)
                .IsRequired();
            builder.Property(a => a.DateCreate)
                .IsRequired();
        }
    }
}
