using ProgressOS.Application.Abstractions;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;

namespace ProgressOS.Application.Services
{
    public class GoalsYearService : IGoalsYearService
    {
        private readonly IGoalsYearRepository _repository;
        public GoalsYearService(IGoalsYearRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddAsync(GoalsYear goalsYear, CancellationToken token)
        {
            return await _repository.AddAsync(goalsYear, token);
        }
        public async Task<bool> CheckAsync(string name, CancellationToken token)
        {
            return await _repository.CheckAsync(name, token);
        }
        public async Task<int> DeleteAsync(string name, CancellationToken token)
        {
            return await _repository.DeleteAsync(name, token);
        }
        public async Task<List<GoalsYear>> GetAllAsync(CancellationToken token)
        {
            return await _repository.GetAllAsync(token);
        }
    }
}
