using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationSystem.EndPoints.PanelWebApi.Models.BaseModels
{
    public class BaseApiResultModel
    {
        public bool IsSuccess { get; set; }
        public ResultStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }

        public BaseApiResultModel(ResultStatusCode statuscode, bool issuccess = false, string message = null, object result = null)
        {
            IsSuccess = issuccess;
            Result = result;
            StatusCode = issuccess ? ResultStatusCode.Success : statuscode;
            ErrorMessage = message ?? StatusCode.ToDisplay();
        }
    }
}
