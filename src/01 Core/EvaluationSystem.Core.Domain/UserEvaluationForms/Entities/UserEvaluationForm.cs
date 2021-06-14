using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using EvaluationSystem.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.UserEvaluationForms.Entities
{
    public class UserEvaluationForm
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public  EvaluationForm EvaluationForm { get; set; }
        public int EvaluationFormId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public List<UserEvaluationFormDetail> FormDetails  { get; set; }
    }
}
