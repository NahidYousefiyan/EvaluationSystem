using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos
{
    public class UserEvaluationFormResultDto
    {
        public int Id { get; set; }
        public string FormTitle { get; set; }
        public string IndexTitle { get; set; }
        public DateTime? RegisterDate { get; set; }
        public List<UserEvaluationFormQuestionResultDto> Questions { get; set; }

    }
}
