using System.ComponentModel.DataAnnotations;

namespace EvaluationSystem.Core.Domain.Users.Enums
{
    public enum UserGroup
    {
        [Display(Name = "دانشجو")]
        Student =1,
        [Display(Name = "گروه علمی")]
        Teacher =2,
        [Display(Name = "مدیریت دانشگاه")]
        UniversityManagement =3,
        [Display(Name = "مدیریت دانشکده")]
        CollegeManagement =4,
        [Display(Name = "کارشناس آموزش دانشکده")]
        CollegeEmployee =5
    }
}
