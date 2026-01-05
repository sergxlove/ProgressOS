using ProgressOS.Core.Models;

namespace ProgressOS.DataAccess.Sqlite.Abstractions
{
    public interface IGoalsDayRepository
    {
        Task<Guid> AddAsync(GoalsDay goalsDay, CancellationToken token);
        Task<bool> CheckAsync(string name, CancellationToken token);
        Task<int> DeleteAsync(string name, CancellationToken token);
        Task<List<GoalsDay>> GetAllAsync(CancellationToken token);
    }
}