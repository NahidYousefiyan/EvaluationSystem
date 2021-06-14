using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Repositories;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.Users.Enums;
using System.Linq;

namespace EvaluationSystem.Core.ApplicationServices.Reporting
{
    public class ReportingService : IReportingService
    {
        private readonly IReportRepository reportRepository;

        public ReportingService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public ServiceResult<EvaluationReportResultDto> CollegeScore(EvaluationReportDto reportDto)
        {
            var Data = reportRepository.CollegeScoreReport(reportDto.UserId);
            if (Data == null)
                return new ServiceResult<EvaluationReportResultDto>(ResultStatusCode.NotFound, false);

            var Result = new EvaluationReportResultDto()
            {
                ResultDetail = Data,
                ResultAggregate = new EvaluationReportResultAggregateDto()
                {
                    ItemCount = Data.Count,
                    SumGrade = Data.Sum(x => x.SumGrade),
                    Avg = (Data.Count > 0 && Data.Sum(x => x.SumGrade) > 0) ? Data.Sum(x => x.SumGrade) / Data.Count : 0
                }
            };


            return new ServiceResult<EvaluationReportResultDto>(ResultStatusCode.Success, true, result: Result);
        }
    }
}
