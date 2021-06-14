using AutoMapper;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;
using EvaluationSystem.EndPoints.PanelWebApi.Models.EvaluationFormModels;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.MapperConfig
{
    public class EvaluationFormMappConfig:Profile
    {
        public EvaluationFormMappConfig()
        {
            CreateMap<RegisterFormModel, UserEvaluationFormRegisterDto>();
        }
    }
}
