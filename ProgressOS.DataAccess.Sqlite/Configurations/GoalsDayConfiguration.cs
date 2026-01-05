using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Configurations
{
    public class GoalsDayConfiguration : IEntityTypeConfiguration<GoalsDayEntity>
    {
        public void Configure(EntityTypeBuilder<GoalsDayEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
