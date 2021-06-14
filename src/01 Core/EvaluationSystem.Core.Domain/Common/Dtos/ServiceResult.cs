using EvaluationSystem.Core.Domain.Common.Enums;

namespace EvaluationSystem.Core.Domain.Common.Dtos
{
    public class ServiceResult
    {
        public bool IsSuccess { get; private set; }
        public ResultStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ServiceResult(ResultStatusCode statuscode, bool issuccess = false, string message = null)
        {
            if (statuscode != ResultStatusCode.Success)
                issuccess = false;

            if (statuscode == ResultStatusCode.Success)
                issuccess = true;

            this.IsSuccess = issuccess;
            this.StatusCode = issuccess ? ResultStatusCode.Success : statuscode;
            this.ErrorMessage = message;
        }
    }

    public sealed class ServiceResult<TData> : ServiceResult
    {
        public ServiceResult(ResultStatusCode statuscode, bool issuccess = false, string message = null, TData result = default(TData)) : base(statuscode, issuccess, message)
        {
            Result = result;
        }

        public TData Result { get; private set; }
    }
}
