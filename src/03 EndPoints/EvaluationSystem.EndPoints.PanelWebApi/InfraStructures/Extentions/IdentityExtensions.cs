using EvaluationSystem.Core.Domain.Users.Enums;
using EvaluationSystem.Infra.Resources;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace EvaluationSystem.EndPoints.PanelWebApi.InfraStructures.Extentions
{
    public static class IdentityExtensions
    {
        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            return identity?.FindFirst(claimType)?.Value;
        }

        public static string FindFirstValue(this IIdentity identity, string claimType)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity?.FindFirstValue(claimType);
        }

        public static int GetUserId(this IIdentity identity)
        {
            if (identity != null)
            {
                //var id = identity.FindFirstValue(ClaimTypes.NameIdentifier);
                var id = identity.FindFirstValue(IdentityClaimsResource.UserIdKeyName);
                try
                {
                    return Convert.ToInt32(id);
                }
                catch
                {

                }               
            }
            return -1;
        }

        public static UserGroup GetUserGroup(this IIdentity identity)
        {
            if (identity != null)
            {                
               
               
                try
                {
                    var id = identity.FindFirstValue(IdentityClaimsResource.UserGroupKeyName);
                    UserGroup userGroup = (UserGroup)Enum.Parse(typeof(UserGroup), id);
                    return userGroup;
                }
                catch
                {

                }
            }
            return 0;
        }
        public static string GetUserName(this IIdentity identity)
        {
            return identity?.FindFirstValue(IdentityClaimsResource.UserNameKeyName);
        }

        public static string GetUserFullName(this IIdentity identity)
        {
            return identity?.FindFirstValue(IdentityClaimsResource.UserFullNameKeyName);
        }

      
                       
    }
}
