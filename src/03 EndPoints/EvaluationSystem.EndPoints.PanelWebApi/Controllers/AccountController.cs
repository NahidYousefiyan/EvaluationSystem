using AutoMapper;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.Core.Domain.Users.Services;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.ActionFilters;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Extentions;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Services;
using EvaluationSystem.EndPoints.PanelWebApi.Models.Account;
using EvaluationSystem.Infra.Resources;
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
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;

        public AccountController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, [FromServices] IUserLoginService loginService)
        {
            var loginDto = mapper.Map<UserLoginDto>(model);
            var Result = loginService.Handel(loginDto);
            return ResponseService.Generate<UserLoginResultDto>(Result);
        }

        [HttpGet]
        [Route("GetInfo")]
        [ServiceFilter(typeof(CustomAuthorizeActionFilterAttribute))]
        public async Task<IActionResult>GetCurrentUserInfo([FromServices] IUserQueryService userQueryService)
        {
            var Result = userQueryService.GetUserInfoById(HttpContext.User.Identity.GetUserId());
            return ResponseService.Generate<UserInfoResultDto>(Result);
        }

        [HttpGet]
        [Route("LogOut")]
        [ServiceFilter(typeof(CustomAuthorizeActionFilterAttribute))]
        public async Task<IActionResult> LogOut([FromServices] IUserLogoutService logoutService)
        {
            var Result = logoutService.Handel(new UserLogoutDto
            {
                UserId = HttpContext.User.Identity.GetUserId(),
                AccessToken = HttpContext.Request.Headers[HttpItemsResource.AccessTokenKeyName]
            });

            return ResponseService.Generate(Result);
        }
    }
}
