using ProgressOS.Core.Models;

namespace ProgressOS.DataAccess.Sqlite.Abstractions
{
    public interface IUsersRepository
    {
        Task<Guid> AddAsync(Users user, CancellationToken token);
        Task<bool> CheckAsync(string nickname, CancellationToken token);
        Task<int> DeleteAsync(string nickname, CancellationToken token);
    }
}