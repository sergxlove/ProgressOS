namespace ProgressOS.DataAccess.Sqlite.Models
{
    public class GoalsDayEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CurrentProgress { get; set; } = string.Empty;
        public string TotalProgress { get; set; } = string.Empty;
        public string DateCreate { get; set; } = string.Empty;
    }
}
