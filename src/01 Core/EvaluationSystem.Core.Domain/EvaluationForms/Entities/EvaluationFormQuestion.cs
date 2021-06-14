using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.EvaluationForms.Entities
{
    public class EvaluationFormQuestion
    {
        public int Id { get; set; }              
        public byte Index { get; set; }
        public string Text { get; set; }        
        public byte Weight { get; set; }
        public EvaluationForm Form  { get; set; }
        public int FormId { get; set; }

        public List<EvaluationFormAnswer>  Answers  { get; set; }
    }
}
