using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Utilities.Helpers;
using System;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.CommonServices
{
    public class GuIdTokenService : ITokenGenerateService
    {
        public Task<TokenResultDto> Handle(UserTokenDto userTokenDto)
        {           
            var token = StringHelper.GetBase64(Guid.NewGuid().ToString());
            
            var Result = new TokenResultDto() { Token = token};

            return Task.FromResult(Result);
        }
    }
}
