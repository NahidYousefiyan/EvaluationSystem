using EvaluationSystem.Core.Domain.Common.Dtos;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.Domain.Common.Services
{
    public interface ITokenGenerateService
    {
        Task<TokenResultDto> Handle(UserTokenDto userTokenDto);
    }
}
