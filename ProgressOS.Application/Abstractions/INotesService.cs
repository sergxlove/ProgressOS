using ProgressOS.Core.Models;

namespace ProgressOS.Application.Abstractions
{
    public interface INotesService
    {
        Task<string> AddAsync(Notes note, CancellationToken token);
        Task<int> DeleteAsync(string id, CancellationToken token);
        Task<List<Notes>> GetAllAsync(CancellationToken token);
        Task<int> UpdateDescriptionAsync(Notes note, CancellationToken token);
        Task<int> UpdateTitleAsync(Notes note, CancellationToken token);
    }
}