using ProgressOS.Core.Models;

namespace ProgressOS.Application.Abstractions
{
    public interface IUsersService
    {
        Task<Guid> AddAsync(Users user, CancellationToken token);
        Task<bool> CheckAsync(string nickname, CancellationToken token);
        Task<int> DeleteAsync(string nickname, CancellationToken token);
    }
}