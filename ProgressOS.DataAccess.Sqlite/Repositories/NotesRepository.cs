using Microsoft.EntityFrameworkCore;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;
using ProgressOS.DataAccess.Sqlite.Infrastructures;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ProgressOSDbContext _context;
        public NotesRepository(ProgressOSDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(Notes note, CancellationToken token)
        {
            NotesEntity noteEntity = MapperToEntity.ToNotesEntity(note);
            await _context.AddAsync(noteEntity, token);
            await _context.SaveChangesAsync(token);
            return noteEntity.Id;
        }

        public async Task<int> DeleteAsync(string id, CancellationToken token)
        {
            return await _context.NotesTable
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(token);
        }

        public async Task<List<Notes>> GetAllAsync(CancellationToken token)
        {
            return await _context.NotesTable
                .AsNoTracking()
                .Select(ne => MapperToEntity.FromNotesEntity(ne))
                .ToListAsync(token);
        }

        public async Task<int> UpdateTitleAsync(Notes note, CancellationToken token)
        {
            NotesEntity noteEntity = MapperToEntity.ToNotesEntity(note);
            return await _context.NotesTable
                .AsNoTracking()
                .Where(a => a.Id == noteEntity.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(a => a.Title, noteEntity.Title)
                .SetProperty(a => a.DateUpdate, DateTime.Now.ToString()), token);
        }

        public async Task<int> UpdateDescriptionAsync(Notes note, CancellationToken token)
        {
            NotesEntity noteEntity = MapperToEntity.ToNotesEntity(note);
            return await _context.NotesTable
                .AsNoTracking()
                .Where(a => a.Id == noteEntity.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(a => a.Description, noteEntity.Description)
                .SetProperty(a => a.DateUpdate, DateTime.Now.ToString()), token);
        }
    }
}
