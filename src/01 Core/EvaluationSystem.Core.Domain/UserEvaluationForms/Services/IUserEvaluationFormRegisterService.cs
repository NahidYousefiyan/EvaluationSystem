using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Services
{
    public interface IUserEvaluationFormRegisterService
    {
        ServiceResult Handle(UserEvaluationFormRegisterDto registerDto);
    }
}
