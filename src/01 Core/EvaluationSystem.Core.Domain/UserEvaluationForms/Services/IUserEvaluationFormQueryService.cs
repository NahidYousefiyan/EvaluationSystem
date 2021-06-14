using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Services
{
    public interface IUserEvaluationFormQueryService
    {
        ServiceResult<UserEvaluationFormResultDto> GetUserEvaluationFormWithDetail(UserEvaluationFormDto formDto);
    }
}
