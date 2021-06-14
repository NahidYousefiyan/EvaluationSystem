using EvaluationSystem.Core.Domain.Common.Dtos;
using System.Collections.Generic;

namespace EvaluationSystem.Core.Domain.Common.Services
{
    public interface IReportingService
    {
        ServiceResult<EvaluationReportResultDto> CollegeScore(EvaluationReportDto reportDto);
    }
}
