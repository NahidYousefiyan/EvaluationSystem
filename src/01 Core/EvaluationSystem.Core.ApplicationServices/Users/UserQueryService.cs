using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.Core.Domain.Users.Services;

namespace EvaluationSystem.Core.ApplicationServices.Users
{
    public class UserQueryService : IUserQueryService
    {
        private readonly ICacheProviderService cacheProviderService;

        public UserQueryService(ICacheProviderService cacheProviderService)
        {
            this.cacheProviderService = cacheProviderService;
        }

        public ServiceResult<UserInfoResultDto> GetUserInfoById(int userId)
        {
            var user = cacheProviderService.Get<UserInfoResultDto>(CacheNameSpace.User, userId.ToString());
            if (user == null)
                return new ServiceResult<UserInfoResultDto>(ResultStatusCode.NotFound, false);
            return new ServiceResult<UserInfoResultDto>(ResultStatusCode.Success, true, result: user);            
        }
    }
}
