using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Core.Domain.Common.Enums
{
    public enum ResultStatusCode
    {
        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 1,

        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 2,

        [Display(Name = "یافت نشد")]
        NotFound = 3,

        [Display(Name = "خطایی در پردازش رخ داد")]
        LogicError = 4,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 5,

        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 6       
    }
}
