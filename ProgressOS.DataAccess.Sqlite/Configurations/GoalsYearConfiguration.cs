using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Configurations
{
    public class GoalsYearConfiguration : IEntityTypeConfiguration<GoalsYearEntity>
    {
        public void Configure(EntityTypeBuilder<GoalsYearEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
