using EvaluationSystem.Core.Domain.Common.Data;
using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.EvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Core.ApplicationServices.UserEvaluationForms
{
    public class UserEvaluationFormRegisterService : IUserEvaluationFormRegisterService
    {
        private readonly IUserEvaluationFormRepository userEvaluationFormRepository;
        private readonly IEvaluationFormRepository evaluationFormRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserEvaluationFormRegisterService(IUserEvaluationFormRepository userEvaluationFormRepository, IEvaluationFormRepository evaluationFormRepository, IUnitOfWork unitOfWork)
        {
            this.userEvaluationFormRepository = userEvaluationFormRepository;
            this.evaluationFormRepository = evaluationFormRepository;
            this.unitOfWork = unitOfWork;
        }

        public ServiceResult Handle(UserEvaluationFormRegisterDto registerDto)
        {
            //کنترل وجود فرم
            var form = evaluationFormRepository.GetEvaluationFormById(registerDto.FormId);
            
            if (form == null)
                return new ServiceResult(ResultStatusCode.NotFound, false,message: "فرمی با این آی دی یافت نشد");


            if(form.UserGroup!=registerDto.UserGroup)
                return new ServiceResult(ResultStatusCode.LogicError, false, message: "این کاربر دسترسی به این فرم ندارد");


            var userForm = userEvaluationFormRepository.Load(registerDto.UserId, registerDto.FormId);

            var questionCount = registerDto.QuestionAnswer.Keys.Select(x => x).ToList().Except(form.Questions.Select(x => x.Id).ToList()).Count();
            if (questionCount>0)
                return new ServiceResult(ResultStatusCode.LogicError, false, message: $"آی دی {questionCount} سوال نامعتبر است");

            var answerCount = registerDto.QuestionAnswer.Values.Select(x => x).ToList().Except(form.Questions.SelectMany(x =>x.Answers.Select(y=>y.Id)).ToList()).Count();
            if (answerCount > 0)
                return new ServiceResult(ResultStatusCode.LogicError, false, message: $"آی دی {answerCount} پاسخ نامعتبر است");

            if (userForm == null)
            {
                userForm = new UserEvaluationForm
                {
                    UserId = registerDto.UserId,
                    EvaluationFormId = registerDto.FormId,
                    RegisterDate = DateTime.Now,
                    FormDetails = new List<UserEvaluationFormDetail>()
                };

                foreach (var item in registerDto.QuestionAnswer)
                {
                    var question = form.Questions.Where(x => x.Id == item.Key).FirstOrDefault();
                    if (question != null)
                    {
                        var weightPercent = question.Answers.Where(x => x.Id == item.Value).First().WeightPercent;
                        byte grade = (weightPercent > 0) ? (byte)(question.Weight * weightPercent / 100) : (byte)0;
                        userForm.FormDetails.Add(new UserEvaluationFormDetail { QuestionId = item.Key, AnswerId = item.Value, Grade = grade });
                    }
                }

                userEvaluationFormRepository.AddUserEvaluationForm(userForm);
            }
            else
            {
                var intersect=userForm.FormDetails.Select(x => x.QuestionId).ToList().Intersect(registerDto.QuestionAnswer.Keys.ToList()).ToList();
                foreach (var item in intersect)
                {
                    var deleted = userForm.FormDetails.Where(x => x.QuestionId == item).FirstOrDefault();
                    if (deleted != null)
                        userForm.FormDetails.Remove(deleted);
                }

                foreach (var item in registerDto.QuestionAnswer)
                {
                    var question = form.Questions.Where(x => x.Id == item.Key).FirstOrDefault();
                    if (question != null)
                    {
                        var weightPercent = question.Answers.Where(x => x.Id == item.Value).First().WeightPercent;
                        byte grade = (weightPercent > 0) ? (byte)(question.Weight * weightPercent / 100) : (byte)0;
                        userForm.FormDetails.Add(new UserEvaluationFormDetail { QuestionId = item.Key, AnswerId = item.Value, Grade = grade });
                    }
                }
            }
            
            unitOfWork.Commit();

            return new ServiceResult(ResultStatusCode.Success);           
        }
    }
}
