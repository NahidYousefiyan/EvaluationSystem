using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.Domain.Common.Enums
{
    public enum CacheNameSpace
    {
        [Display(Name = "")]
        None =0,
        [Display(Name = "UT:")]
        UserAccessToken=1,
        [Display(Name = "User:")]
        User=2
    }
}
