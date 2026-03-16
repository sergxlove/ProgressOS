using ProgressOS.Core.Models;

namespace ProgressOS.Application.Abstractions
{
    public interface IGoalsYearService
    {
        Task<Guid> AddAsync(GoalsYear goalsYear, CancellationToken token);
        Task<bool> CheckAsync(string name, CancellationToken token);
        Task<int> DeleteAsync(string name, CancellationToken token);
        Task<List<GoalsYear>> GetAllAsync(CancellationToken token);
    }
}