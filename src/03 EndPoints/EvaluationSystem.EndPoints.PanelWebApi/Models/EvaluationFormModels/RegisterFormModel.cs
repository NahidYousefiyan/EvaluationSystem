using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.EndPoints.PanelWebApi.Models.EvaluationFormModels
{
    public class RegisterFormModel
    {
        [Required]
        public int FormId { get; set; }

        [Required]
        public Dictionary<int, int> QuestionAnswer { get; set; }
    }
}
