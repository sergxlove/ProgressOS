using ProgressOS.Application.Abstractions;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;

namespace ProgressOS.Application.Services
{
    public class GoalsDayService : IGoalsDayService
    {
        private readonly IGoalsDayRepository _repository;
        public GoalsDayService(IGoalsDayRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddAsync(GoalsDay goalsDay, CancellationToken token)
        {
            return await _repository.AddAsync(goalsDay, token);
        }
        public async Task<bool> CheckAsync(string name, CancellationToken token)
        {
            return await _repository.CheckAsync(name, token);
        }
        public async Task<int> DeleteAsync(string name, CancellationToken token)
        {
            return await _repository.DeleteAsync(name, token);
        }
        public async Task<List<GoalsDay>> GetAllAsync(CancellationToken token)
        {
            return await _repository.GetAllAsync(token);
        }
    }
}
