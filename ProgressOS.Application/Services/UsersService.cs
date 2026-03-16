using ProgressOS.Application.Abstractions;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;

namespace ProgressOS.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;
        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> AddAsync(Users user, CancellationToken token)
        {
            return await _repository.AddAsync(user, token);
        }
        public async Task<bool> CheckAsync(string nickname, CancellationToken token)
        {
            return await _repository.CheckAsync(nickname, token);
        }
        public async Task<int> DeleteAsync(string nickname, CancellationToken token)
        {
            return await _repository.DeleteAsync(nickname, token);
        }
    }
}
