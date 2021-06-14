using EvaluationSystem.Core.Domain.Colleges.Entities;

namespace EvaluationSystem.Core.Domain.EvaluationIndexes.Entities
{
    public class EvaluationIndexCollegeWeight
    {
        public int EvaluationIndexId { get; set; }
        public int CollegeId { get; set; }
        public EvaluationIndex EvaluationIndex  { get; set; }
        public College College { get; set; }
        public byte Weight { get; set; }
    }
}
