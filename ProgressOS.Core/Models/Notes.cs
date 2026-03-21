using ProgressOS.Core.Infrastructures;

namespace ProgressOS.Core.Models
{
    public class Notes
    {
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public DateTime DateCreate {  get; }
        public DateTime DateUpdate { get; }

        public static ResultCreateModel<Notes> Create(Guid id, string title, 
            string description, DateTime dateCreate, DateTime dateUpdate)
        {

            return ResultCreateModel<Notes>.Success(new Notes(id, title, description, 
                dateCreate, dateUpdate));
        }

        private Notes(Guid id, string title, string description, DateTime dateCreate, 
            DateTime dateUpdate)
        {
            Id = id;
            Title = title;
            Description = description;
            DateCreate = dateCreate;
            DateUpdate = dateUpdate;
        }

    }
}
