using Microsoft.EntityFrameworkCore;
using ProgressOS.DataAccess.Sqlite.Configurations;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite
{
    public class ProgressOSDbContext : DbContext
    {
        public ProgressOSDbContext(DbContextOptions<ProgressOSDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GoalsDayEntity> GoalsDayTable { get; set; }
        public DbSet<GoalsYearEntity> GoalsYearTable { get; set; }
        public DbSet<UsersEntity> UsersTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoalsDayConfiguration());
            modelBuilder.ApplyConfiguration(new GoalsYearConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
