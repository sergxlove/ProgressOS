using ProgressOS.Core.Models;

namespace ProgressOS.Application.Abstractions
{
    public interface IGoalsDayService
    {
        Task<Guid> AddAsync(GoalsDay goalsDay, CancellationToken token);
        Task<bool> CheckAsync(string name, CancellationToken token);
        Task<int> DeleteAsync(string name, CancellationToken token);
        Task<List<GoalsDay>> GetAllAsync(CancellationToken token);
    }
}