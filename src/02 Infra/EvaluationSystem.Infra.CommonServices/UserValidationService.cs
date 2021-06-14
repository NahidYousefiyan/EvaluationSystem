using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.Core.Domain.Users.Repositories;
using EvaluationSystem.Infra.Resources;
using EvaluationSystem.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.CommonServices
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserRepository userRepository;
        private readonly ICacheProviderService cacheProviderService;

        public UserValidationService(IUserRepository userRepository,ICacheProviderService cacheProviderService)
        {
            this.userRepository = userRepository;
            this.cacheProviderService = cacheProviderService;
        }
        public ServiceResult<List<Claim>> Handle(string accessToken)
        {
            //کنترل موجود بودن توکن
            var userId = cacheProviderService.Get<int?>(CacheNameSpace.UserAccessToken,accessToken);
            if (userId == null)
            {
                var token = userRepository.GetUserAccessToken(accessToken);
                if (token == null)
                    return new ServiceResult<List<Claim>>(ResultStatusCode.UnAuthorized, message: "توکن نا معتبر است");

                userId = token.UserId;
                cacheProviderService.Set(CacheNameSpace.UserAccessToken, token.Token, userId);
            }      

            //در صورتی که توکن یافت شد 
            var User = cacheProviderService.Get<UserInfoResultDto>(CacheNameSpace.User,userId.ToString());
            if (User == null)
            {
                var userInfo = userRepository.GetById(userId.Value);
                
                if (userInfo == null)
                    return new ServiceResult<List<Claim>>(ResultStatusCode.NotFound, message: "کاربر معتبر نمی باشد");

                User = new UserInfoResultDto
                {
                    Id = userInfo.Id,
                    UserName = userInfo.UserName,
                    UserGroup = userInfo.UserGroup,
                    FullName = $"{userInfo.FirstName} {userInfo.LastName}",
                    CollegeId=userInfo.CollegeId,
                    CollegeName=userInfo.College?.CollegeName,
                    UserGroupName = userInfo.UserGroup.ToDisplay()
                };

                cacheProviderService.Set(CacheNameSpace.User, userInfo.Id.ToString(), User);
            }

           

            List<Claim> Claims = new List<Claim>();
            Claims.Add(new Claim(IdentityClaimsResource.UserIdKeyName, User.Id.ToString()));    
            Claims.Add(new Claim(IdentityClaimsResource.UserNameKeyName, User.UserName));
            Claims.Add(new Claim(IdentityClaimsResource.UserFullNameKeyName, User.FullName));
            Claims.Add(new Claim(IdentityClaimsResource.UserGroupKeyName, User.UserGroup.ToString()));


            return new ServiceResult<List<Claim>>(ResultStatusCode.Success, result: Claims);
        }
    }
}
