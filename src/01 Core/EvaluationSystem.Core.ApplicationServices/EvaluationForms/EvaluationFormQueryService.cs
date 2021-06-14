using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.EvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.EvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.EvaluationForms.Services;
using EvaluationSystem.Core.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.ApplicationServices.EvaluationForms
{
    public class EvaluationFormQueryService : IEvaluationFormQueryService
    {
        private readonly IEvaluationFormRepository evaluationFormRepository;

        public EvaluationFormQueryService(IEvaluationFormRepository evaluationFormRepository)
        {
            this.evaluationFormRepository = evaluationFormRepository;
        }


        public ServiceResult<List<EvaluationFormResultDto>> GetEvaluationFormList(UserGroup userGroup)
        {
            var Data = evaluationFormRepository.GetEvaluationFormList(userGroup);
            if (Data == null)
                return new ServiceResult<List<EvaluationFormResultDto>>(ResultStatusCode.NotFound, false);
           
            var Result = Data.Select(x => new EvaluationFormResultDto
            {
                Id=x.Id,
                FormTitle=x.Description,
                IndexTitle=x.EvaluationIndex.Title
            }).ToList();

            return new ServiceResult<List<EvaluationFormResultDto>>(ResultStatusCode.Success, true, result: Result);            
        }
    }
}
