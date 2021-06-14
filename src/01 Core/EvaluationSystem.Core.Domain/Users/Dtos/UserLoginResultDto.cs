using EvaluationSystem.Core.Domain.Users.Enums;

namespace EvaluationSystem.Core.Domain.Users.Dtos
{
    public class UserLoginResultDto
    {      
        public string AccessToken { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
