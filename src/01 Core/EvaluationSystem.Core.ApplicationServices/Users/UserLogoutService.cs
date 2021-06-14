using EvaluationSystem.Core.Domain.Common.Data;
using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.Core.Domain.Users.Repositories;
using EvaluationSystem.Core.Domain.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Core.ApplicationServices.Users
{
    public class UserLogoutService : IUserLogoutService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICacheProviderService cacheProviderService;

        public UserLogoutService(IUserRepository userRepository,  IUnitOfWork unitOfWork, ICacheProviderService cacheProviderService)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.cacheProviderService = cacheProviderService;
        }


        public ServiceResult Handel(UserLogoutDto userDto)
        {
            var user = userRepository.GetById(userDto.UserId);
            if (user == null)
                return new ServiceResult(ResultStatusCode.LogicError, false, message: "کاربری یافت نشد");

            cacheProviderService.Delete(CacheNameSpace.UserAccessToken, userDto.AccessToken);
            cacheProviderService.Delete(CacheNameSpace.User, userDto.UserId.ToString());

            return new ServiceResult(ResultStatusCode.Success, true);
        }
    }
}
