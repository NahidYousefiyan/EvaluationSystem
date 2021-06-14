using EvaluationSystem.Core.Domain.Common.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.Common.Repositories
{
    public interface IReportRepository
    {
        List<EvaluationReportResultDetailDto> CollegeScoreReport(int userId);
    }
}
