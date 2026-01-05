using Microsoft.EntityFrameworkCore;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;
using ProgressOS.DataAccess.Sqlite.Infrastructures;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Repositories
{
    public class GoalsYearRepository : IGoalsYearRepository
    {
        private readonly ProgressOSDbContext _context;
        public GoalsYearRepository(ProgressOSDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(GoalsYear goalsYear, CancellationToken token)
        {
            GoalsYearEntity goalEntity = MapperToEntity.ToGoalsYearEntity(goalsYear);
            await _context.GoalsYearTable.AddAsync(goalEntity, token);
            await _context.SaveChangesAsync(token);
            return goalsYear.Id;
        }

        public async Task<int> DeleteAsync(string name, CancellationToken token)
        {
            return await _context.GoalsYearTable
                .Where(a => a.Name == name)
                .ExecuteDeleteAsync(token);
        }

        public async Task<bool> CheckAsync(string name, CancellationToken token)
        {
            GoalsYearEntity? result = await _context.GoalsYearTable
                .FirstOrDefaultAsync(a => a.Name == name);
            if (result is null) return false;
            return true;
        }

        public async Task<List<GoalsYear>> GetAllAsync(CancellationToken token)
        {
            List<GoalsYearEntity> resultEntity = await _context.GoalsYearTable
                .ToListAsync(token);
            List<GoalsYear> result = new List<GoalsYear>();
            foreach (GoalsYearEntity g in resultEntity)
            {
                result.Add(MapperToEntity.FromGoalsYearEntity(g));
            }
            return result;
        }

    }
}
