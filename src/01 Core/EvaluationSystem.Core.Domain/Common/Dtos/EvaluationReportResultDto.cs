using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.Common.Dtos
{
    public class EvaluationReportResultDto
    {
        public List<EvaluationReportResultDetailDto> ResultDetail { get; set; }
        public EvaluationReportResultAggregateDto ResultAggregate  { get; set; }
    }

    public class EvaluationReportResultDetailDto
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public int EvaluationIndexeId { get; set; }
        public string EvaluationIndexeTitle { get; set; }
        public int SumGrade { get; set; }
        public int SumWeight { get; set; }
        public int IndexWeight { get; set; }
    }

    public class EvaluationReportResultAggregateDto
    {
        public int ItemCount { get; set; }
        public int SumGrade { get; set; }
        public decimal Avg { get; set; }
    }
}
