using EvaluationSystem.Core.Domain.Users.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos
{
    public class UserEvaluationFormRegisterDto
    {
        public int FormId { get; set; }
        public int UserId { get; set; }
        public UserGroup UserGroup { get; set; }
        public Dictionary<int,int> QuestionAnswer { get; set; }
    }
    
}
