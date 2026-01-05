using Microsoft.EntityFrameworkCore;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;
using ProgressOS.DataAccess.Sqlite.Infrastructures;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Repositories
{
    public class GoalsDayRepository : IGoalsDayRepository
    {
        private readonly ProgressOSDbContext _context;
        public GoalsDayRepository(ProgressOSDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(GoalsDay goalsDay, CancellationToken token)
        {
            GoalsDayEntity goalEntity = MapperToEntity.ToGoalsDayEntity(goalsDay);
            await _context.GoalsDayTable.AddAsync(goalEntity, token);
            await _context.SaveChangesAsync(token);
            return goalsDay.Id;
        }

        public async Task<int> DeleteAsync(string name, CancellationToken token)
        {
            return await _context.GoalsDayTable
                .Where(a => a.Name == name)
                .ExecuteDeleteAsync(token);
        }

        public async Task<bool> CheckAsync(string name, CancellationToken token)
        {
            GoalsDayEntity? result = await _context.GoalsDayTable
                .FirstOrDefaultAsync(a => a.Name == name);
            if (result is null) return false;
            return true;
        }

        public async Task<List<GoalsDay>> GetAllAsync(CancellationToken token)
        {
            List<GoalsDayEntity> resultEntity = await _context.GoalsDayTable
                .ToListAsync(token);
            List<GoalsDay> result = new List<GoalsDay>();
            foreach (GoalsDayEntity g in resultEntity)
            {
                result.Add(MapperToEntity.FromGoalsDayEntity(g));
            }
            return result;
        }
    }
}
