using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Repositories
{
    public interface IUserEvaluationFormRepository
    {
        UserEvaluationForm Load(int userId, int fromId);
        UserEvaluationForm GetUserEvaluationForm(int userId,int fromId);
        void AddUserEvaluationForm(UserEvaluationForm entity);
    }
}
