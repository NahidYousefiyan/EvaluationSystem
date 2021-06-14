using AutoMapper;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.EndPoints.PanelWebApi.Models.Account;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.MapperConfig
{
    public class AccountMappConfig:Profile
    {
        public AccountMappConfig()
        {
            CreateMap<LoginModel, UserLoginDto>();
        }
    }
}
