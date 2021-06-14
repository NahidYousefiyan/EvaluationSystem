using EvaluationSystem.Core.Domain.EvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using EvaluationSystem.Core.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.Domain.EvaluationForms.Repositories
{
    public interface IEvaluationFormRepository
    {
        List<EvaluationForm> GetEvaluationFormList(UserGroup userGroup);
        EvaluationForm GetEvaluationFormById(int formId);
    }
}
