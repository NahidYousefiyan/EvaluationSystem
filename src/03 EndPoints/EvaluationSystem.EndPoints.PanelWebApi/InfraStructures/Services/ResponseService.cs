using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.EndPoints.PanelWebApi.Models.BaseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Services
{
    public static class ResponseService
    {
        public static IActionResult Success()
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: true, statuscode: ResultStatusCode.Success));
        }

        public static IActionResult Success(object data = null)
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: true, statuscode: ResultStatusCode.Success,result:data));
        }

        public static IActionResult NotFound()
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: false , statuscode: ResultStatusCode.NotFound));
        }

        public static IActionResult Faild(string message)
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: false, statuscode: ResultStatusCode.LogicError,message:message));
        }

        public static IActionResult UnAuthorized()
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: false, statuscode: ResultStatusCode.UnAuthorized));
        }
        public static IActionResult BadRequest(string message=null)
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: false, statuscode: ResultStatusCode.BadRequest,message:message));
        }

        public static IActionResult ServerError(string message = null)
        {
            return new OkObjectResult(new BaseApiResultModel(issuccess: false, statuscode: ResultStatusCode.ServerError, message: message));
        }
        public static IActionResult Generate(ServiceResult result)
        {
            if (result.StatusCode == ResultStatusCode.Success)
                return Success();
            else if (result.StatusCode == ResultStatusCode.NotFound)
                return NotFound();
            else if (result.StatusCode == ResultStatusCode.LogicError)
                return Faild(result.ErrorMessage);
            else if (result.StatusCode == ResultStatusCode.UnAuthorized)
                return UnAuthorized();
            else if (result.StatusCode == ResultStatusCode.BadRequest)
                return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == ResultStatusCode.ServerError)
                return ServerError(result.ErrorMessage);

            throw new ArgumentException("State Is Not Valid");
        }

        public static IActionResult Generate(ResultStatusCode statusCode,string message=null)
        {
            if (statusCode == ResultStatusCode.Success)
                return Success();
            else if (statusCode == ResultStatusCode.NotFound)
                return NotFound();
            else if (statusCode == ResultStatusCode.LogicError)
                return Faild(message);
            else if (statusCode == ResultStatusCode.UnAuthorized)
                return UnAuthorized();
            else if (statusCode == ResultStatusCode.BadRequest)
                return BadRequest(message);
            else if (statusCode == ResultStatusCode.ServerError)
                return ServerError(message);

            throw new ArgumentException("State Is Not Valid");
        }
        public static IActionResult Generate<T>(ServiceResult<T> result)
        {
            if (result.StatusCode == ResultStatusCode.Success)
                return Success(result.Result);
            else if (result.StatusCode == ResultStatusCode.NotFound)
                return NotFound();
            else if (result.StatusCode == ResultStatusCode.LogicError)
                return Faild(result.ErrorMessage);
            else if (result.StatusCode == ResultStatusCode.UnAuthorized)
                return UnAuthorized();
            else if (result.StatusCode == ResultStatusCode.BadRequest)
                return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == ResultStatusCode.ServerError)
                return ServerError(result.ErrorMessage);

            throw new ArgumentException("State Is Not Valid");
        }
    }
}
