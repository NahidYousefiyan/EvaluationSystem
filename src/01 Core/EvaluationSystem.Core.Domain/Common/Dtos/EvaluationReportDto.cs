using EvaluationSystem.Core.Domain.Users.Enums;

namespace EvaluationSystem.Core.Domain.Common.Dtos
{
    public class EvaluationReportDto
    {
        public UserGroup UserGroup { get; set; }
        public int UserId { get; set; }
    }
}
