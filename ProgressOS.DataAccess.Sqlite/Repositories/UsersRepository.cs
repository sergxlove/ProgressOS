using Microsoft.EntityFrameworkCore;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;
using ProgressOS.DataAccess.Sqlite.Infrastructures;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProgressOSDbContext _context;
        public UsersRepository(ProgressOSDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Users user, CancellationToken token)
        {
            UsersEntity userEntity = MapperToEntity.ToUsersEntitty(user);
            await _context.UsersTable.AddAsync(userEntity, token);
            await _context.SaveChangesAsync(token);
            return user.Id;
        }

        public async Task<bool> CheckAsync(string nickname, CancellationToken token)
        {
            UsersEntity? result = await _context.UsersTable
                .FirstOrDefaultAsync(a => a.Nickname == nickname, token);
            if (result is null) return false;
            return true;
        }

        public async Task<int> DeleteAsync(string nickname, CancellationToken token)
        {
            return await _context.UsersTable
                .Where(a => a.Nickname == nickname)
                .ExecuteDeleteAsync(token);
        }
    }
}
