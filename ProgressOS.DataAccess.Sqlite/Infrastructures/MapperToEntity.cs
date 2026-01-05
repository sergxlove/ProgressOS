using ProgressOS.Core.Infrastructures;
using ProgressOS.Core.Models;
using ProgressOS.DataAccess.Sqlite.Models;

namespace ProgressOS.DataAccess.Sqlite.Infrastructures
{
    public class MapperToEntity
    {
        public static UsersEntity ToUsersEntitty(Users user)
        {
            UsersEntity result = new()
            {
                Id = user.Id.ToString(),
                Nickname = user.Nickname,
            };
            return result;
        }

        public static GoalsDayEntity ToGoalsDayEntity(GoalsDay goalsDay)
        {
            GoalsDayEntity result = new()
            {
                Id = goalsDay.Id.ToString(),
                Name = goalsDay.Name,
                Description = goalsDay.Description,
                CurrentProgress = goalsDay.CurrentProgress.ToString(),
                TotalProgress = goalsDay.TotalProgress.ToString(),
                DateCreate = goalsDay.DateCreate.ToString()
            };
            return result;
        }

        public static GoalsYearEntity ToGoalsYearEntity(GoalsYear goalsYear)
        {
            GoalsYearEntity result = new()
            {
                Id = goalsYear.Id.ToString(),
                Name = goalsYear.Name,
                Description = goalsYear.Description,
                CurrentProgress = goalsYear.CurrentProgress.ToString(),
                TotalProgress = goalsYear.TotalProgress.ToString(),
                DateCreate = goalsYear.DateCreate.ToString()
            };
            return result;
        }

        public static Users FromUsersEntity(UsersEntity user)
        {
            ResultCreateModel<Users> result = Users.Create(Guid.Parse(user.Id), user.Nickname);
            if (result.IsSuccess) return result.Value;
            throw new Exception(result.Error);
        }

        public static GoalsDay FromGoalsDayEntity(GoalsDayEntity goalsDay)
        {
            ResultCreateModel<GoalsDay> result = GoalsDay.Create(Guid.Parse(goalsDay.Id), goalsDay.Name,
                goalsDay.Description, Convert.ToInt32(goalsDay.CurrentProgress),
                Convert.ToInt32(goalsDay.TotalProgress), DateOnly.Parse(goalsDay.DateCreate));
            if(result.IsSuccess) return result.Value;
            throw new Exception(result.Error);
        }

        public static GoalsYear FromGoalsYearEntity(GoalsYearEntity goalYear)
        {
            ResultCreateModel<GoalsYear> result = GoalsYear.Create(Guid.Parse(goalYear.Id), goalYear.Name,
                goalYear.Description, Convert.ToInt32(goalYear.CurrentProgress),
                Convert.ToInt32(goalYear.TotalProgress), DateOnly.Parse(goalYear.DateCreate));
            if (result.IsSuccess) return result.Value;
            throw new Exception(result.Error);
        }
    }
}
