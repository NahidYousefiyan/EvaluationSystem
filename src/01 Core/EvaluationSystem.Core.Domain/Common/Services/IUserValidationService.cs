using EvaluationSystem.Core.Domain.Common.Dtos;
using System.Collections.Generic;
using System.Security.Claims;

namespace EvaluationSystem.Core.Domain.Common.Services
{
    public interface IUserValidationService
    {
        ServiceResult<List<Claim>> Handle(string accessToken);
    }
}
