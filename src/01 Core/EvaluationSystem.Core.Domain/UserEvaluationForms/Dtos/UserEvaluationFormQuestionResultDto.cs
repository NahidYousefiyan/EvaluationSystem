using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos
{
    public class UserEvaluationFormQuestionResultDto
    {
        public int Id { get; set; }
        public byte Index { get; set; }
        public string Text { get; set; }    
        public List<UserEvaluationFormAnswerResultDto> Answers { get; set; }
        public int? UserChoiceId { get; set; }
    }
}
