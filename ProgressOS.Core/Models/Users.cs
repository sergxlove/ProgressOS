using ProgressOS.Core.Infrastructures;

namespace ProgressOS.Core.Models
{
    public class Users
    {
        public Guid Id { get; }
        public string Nickname { get; } = string.Empty;

        public static ResultCreateModel<Users> Create(Guid id, string nickname)
        {

            return ResultCreateModel<Users>.Success(new(id, nickname));
        }

        private Users(Guid id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

    }
}
