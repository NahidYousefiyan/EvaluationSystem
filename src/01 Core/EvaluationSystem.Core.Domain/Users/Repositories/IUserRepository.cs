using EvaluationSystem.Core.Domain.Users.Entities;

namespace EvaluationSystem.Core.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        User GetById(int userId);
        User GetByUserName(string userName);
        void StoreAccessToken(int userId,string token);
        UserAccessToken GetUserAccessToken(int userId);
        UserAccessToken GetUserAccessToken(string  accessToken);
    }
}
