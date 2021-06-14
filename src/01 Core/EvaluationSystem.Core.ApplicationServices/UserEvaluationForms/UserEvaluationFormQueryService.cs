using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.EvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.ApplicationServices.UserEvaluationForms
{
    public class UserEvaluationFormQueryService : IUserEvaluationFormQueryService
    {
        private readonly IUserEvaluationFormRepository userEvaluationFormRepository;
        private readonly IEvaluationFormRepository evaluationFormRepository;

        public UserEvaluationFormQueryService(IUserEvaluationFormRepository userEvaluationFormRepository, IEvaluationFormRepository evaluationFormRepository )
        {
            this.userEvaluationFormRepository = userEvaluationFormRepository;
            this.evaluationFormRepository = evaluationFormRepository;
        }
        public ServiceResult<UserEvaluationFormResultDto> GetUserEvaluationFormWithDetail(UserEvaluationFormDto formDto)
        {
            var form = evaluationFormRepository.GetEvaluationFormById(formDto.FormId);
            var userForm = userEvaluationFormRepository.GetUserEvaluationForm(formDto.UserId, formDto.FormId);
            if (form == null)
                return new ServiceResult<UserEvaluationFormResultDto>(ResultStatusCode.NotFound);

            var Result = new UserEvaluationFormResultDto
            {
                Id=form.Id,
                FormTitle=form.Description,
                IndexTitle=form.EvaluationIndex.Title,
                Questions=form.Questions.Select(x=>new UserEvaluationFormQuestionResultDto { 
                    Id=x.Id,
                    Index=x.Index,
                    Text=x.Text.Replace("\n", "").Replace("\r", "").Trim(),
                    Answers=x.Answers.Select(y=>new UserEvaluationFormAnswerResultDto
                    {
                        Id=y.Id,
                        Index=y.Index,
                        Text=y.Text.Replace("\n", "").Replace("\r", "").Trim()
                    }).OrderBy(y=>y.Index).ToList()
                }).OrderBy(x=>x.Index).ToList()               
            };
           
            if (userForm == null || userForm.FormDetails==null )
                return new ServiceResult<UserEvaluationFormResultDto>(ResultStatusCode.Success, true,result:Result);

            Result.RegisterDate = userForm.RegisterDate;

            foreach (var item in Result.Questions)
            {
                item.Text= item.Text.Replace("\n", "").Replace("\r", "");
                var formDetailItem=userForm.FormDetails.Where(x => x.QuestionId == item.Id).FirstOrDefault();
                if (formDetailItem != null)
                    item.UserChoiceId = formDetailItem.AnswerId;
            }

            return new ServiceResult<UserEvaluationFormResultDto>(ResultStatusCode.Success, true, result: Result);
        }
    }
}
