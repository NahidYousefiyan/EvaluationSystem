using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Services;
using EvaluationSystem.Infra.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.ActionFilters
{
    public class CustomAuthorizeActionFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IUserValidationService userValidationService;

        public CustomAuthorizeActionFilterAttribute(IUserValidationService userValidationService )
        {
            this.userValidationService = userValidationService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var accessToken = context.HttpContext.Request.Headers[HttpItemsResource.AccessTokenKeyName];
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(accessToken))
            {
                context.Result = ResponseService.Generate(ResultStatusCode.UnAuthorized);
                return;
            }

            var ValidationResult = userValidationService.Handle(accessToken);
            if (!ValidationResult.IsSuccess)
                context.Result = ResponseService.Generate(ValidationResult);
            else
                context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(ValidationResult.Result, CookieAuthenticationDefaults.AuthenticationScheme));
        }
    }
}
