namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Entities
{
    public class UserEvaluationFormDetail
    {
        public int Id { get; set; }
        public  UserEvaluationForm UserEvaluationForm { get; set; }
        public int UserEvaluationFormId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public byte Grade { get; set; }
    }
}
