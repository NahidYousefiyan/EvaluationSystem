using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.EvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.Domain.EvaluationForms.Services
{
    public interface IEvaluationFormQueryService
    {
        ServiceResult<List<EvaluationFormResultDto>> GetEvaluationFormList(UserGroup userGroup);
    }
}
