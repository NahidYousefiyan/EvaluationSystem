using AutoMapper;
using EvaluationSystem.Core.Domain.EvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.EvaluationForms.Services;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Services;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.ActionFilters;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Extentions;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Services;
using EvaluationSystem.EndPoints.PanelWebApi.Models.EvaluationFormModels;
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
    public class EvaluationFormController : ControllerBase
    {
        private readonly IMapper mapper;

        public EvaluationFormController(IMapper mapper)
        {
            this.mapper = mapper;
        }
       

        [HttpGet]
        [Route("GetFormList")]
        public async Task<IActionResult>GetFormList([FromServices] IEvaluationFormQueryService evaluationFormQueryService)
        {
            var Result =evaluationFormQueryService.GetEvaluationFormList(HttpContext.User.Identity.GetUserGroup());
            return ResponseService.Generate<List<EvaluationFormResultDto>>(Result);
        }

        [HttpGet]
        [Route("GetFormDetail")]
        public async Task<IActionResult>GetFormDetail([FromQuery]int formId,[FromServices] IUserEvaluationFormQueryService userEvaluationFormQueryService)
        {
            var Result = userEvaluationFormQueryService.GetUserEvaluationFormWithDetail(new UserEvaluationFormDto
            {
                UserId= HttpContext.User.Identity.GetUserId(),
                FormId=formId
            });

            return ResponseService.Generate<UserEvaluationFormResultDto>(Result);
        }


        [HttpPost]
        public async Task<IActionResult>RegisterForm([FromBody] RegisterFormModel model, [FromServices] IUserEvaluationFormRegisterService userEvaluationFormRegisterService)
        {
            var dto = mapper.Map<UserEvaluationFormRegisterDto>(model);
            dto.UserId = HttpContext.User.Identity.GetUserId();
            dto.UserGroup = HttpContext.User.Identity.GetUserGroup();
            var Result = userEvaluationFormRegisterService.Handle(dto);
            return ResponseService.Generate(Result);
        }
    }
}
