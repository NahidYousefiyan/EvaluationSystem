using EvaluationSystem.Core.Domain.EvaluationIndexes.Entities;
using EvaluationSystem.Core.Domain.Users.Enums;
using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.EvaluationForms.Entities
{
    public class EvaluationForm
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EvaluationIndex EvaluationIndex  { get; set; }
        public int EvaluationIndexId { get; set; }
        public UserGroup UserGroup  { get; set; }

        public List<EvaluationFormQuestion> Questions  { get; set; }
    }
}
