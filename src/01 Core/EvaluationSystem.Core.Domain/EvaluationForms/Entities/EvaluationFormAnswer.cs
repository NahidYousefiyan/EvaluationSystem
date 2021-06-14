namespace EvaluationSystem.Core.Domain.EvaluationForms.Entities
{
    public class EvaluationFormAnswer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte Index { get; set; }
        public byte WeightPercent { get; set; }
        public EvaluationFormQuestion Question  { get; set; }
        public int QuestionId { get; set; }
    }
}
