using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Users.Dtos;

namespace EvaluationSystem.Core.Domain.Users.Services
{
    public interface IUserLoginService
    {
        ServiceResult<UserLoginResultDto> Handel(UserLoginDto userDto);
    }
}
