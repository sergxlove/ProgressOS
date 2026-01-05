using ProgressOS.Core.Infrastructures;

namespace ProgressOS.Core.Models
{
    public class GoalsDay
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public int CurrentProgress { get; }
        public int TotalProgress { get; }
        public DateOnly DateCreate { get; }

        public static ResultCreateModel<GoalsDay> Create(string name, string description, 
            int totalProgress)
        {


            return ResultCreateModel<GoalsDay>.Success(new(Guid.NewGuid(), name, description, 0,
                totalProgress, DateOnly.FromDateTime(DateTime.Now)));
        }

        public static ResultCreateModel<GoalsDay> Create(Guid id, string name, string description, int currentProgress,
            int totalProgress, DateOnly dateCreate)
        {
            if (id == Guid.Empty)
                return ResultCreateModel<GoalsDay>.Failure("id is empty");

            return ResultCreateModel<GoalsDay>.Success(new(id, name, description, currentProgress,
                totalProgress, dateCreate));
        }

        private GoalsDay(Guid id, string name, string description, int currentProgress, 
            int totalProgress, DateOnly dateCreate)
        {
            Id = id;
            Name = name;
            Description = description;
            CurrentProgress = currentProgress;
            TotalProgress = totalProgress;
            DateCreate = dateCreate;    
        }
    }
}
