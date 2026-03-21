namespace ProgressOS.DataAccess.Sqlite.Models
{
    public class NotesEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DateCreate { get; set; } = string.Empty;
        public string DateUpdate { get; set; } = string.Empty;
    }
}
