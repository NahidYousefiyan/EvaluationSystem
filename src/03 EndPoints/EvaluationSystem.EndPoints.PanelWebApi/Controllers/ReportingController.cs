using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.ActionFilters;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Extentions;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.EndPoints.PanelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomAuthorizeActionFilterAttribute))]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService reportingService;

        public ReportingController(IReportingService reportingService)
        {
            this.reportingService = reportingService;
        }

        [HttpGet]
        [Route("GetCollegeScore")]
        public async Task<IActionResult> CollegeScore()
        {
            var Result = reportingService.CollegeScore(new EvaluationReportDto
            {
                UserGroup = HttpContext.User.Identity.GetUserGroup(),
                UserId = HttpContext.User.Identity.GetUserId()
            });

            return ResponseService.Generate<EvaluationReportResultDto>(Result);
        }
    }
}
