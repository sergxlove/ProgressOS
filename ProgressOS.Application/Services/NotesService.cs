using ProgressOS.Application.Abstractions;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Abstractions;

namespace ProgressOS.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _repository;
        public NotesService(INotesRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> AddAsync(Notes note, CancellationToken token)
        {
            return await _repository.AddAsync(note, token);
        }
        public async Task<int> DeleteAsync(string id, CancellationToken token)
        {
            return await _repository.DeleteAsync(id, token);
        }
        public async Task<List<Notes>> GetAllAsync(CancellationToken token)
        {
            return await _repository.GetAllAsync(token);
        }
        public async Task<int> UpdateDescriptionAsync(Notes note, CancellationToken token)
        {
            return await _repository.UpdateDescriptionAsync(note, token);
        }
        public async Task<int> UpdateTitleAsync(Notes note, CancellationToken token)
        {
            return await _repository.UpdateTitleAsync(note, token);
        }
    }
}
