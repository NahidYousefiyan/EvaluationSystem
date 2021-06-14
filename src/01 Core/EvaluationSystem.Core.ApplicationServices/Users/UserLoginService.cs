using EvaluationSystem.Core.Domain.Common.Data;
using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Enums;
using EvaluationSystem.Core.Domain.Common.Services;
using EvaluationSystem.Core.Domain.Users.Dtos;
using EvaluationSystem.Core.Domain.Users.Repositories;
using EvaluationSystem.Core.Domain.Users.Services;
using EvaluationSystem.Utilities.Helpers;

namespace EvaluationSystem.Core.ApplicationServices.Users
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenGenerateService tokenGenerateService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICacheProviderService cacheProviderService;

        public UserLoginService(IUserRepository userRepository, ITokenGenerateService tokenGenerateService, IUnitOfWork unitOfWork, ICacheProviderService cacheProviderService)
        {
            this.userRepository = userRepository;
            this.tokenGenerateService = tokenGenerateService;
            this.unitOfWork = unitOfWork;
            this.cacheProviderService = cacheProviderService;
        }


        public ServiceResult<UserLoginResultDto> Handel(UserLoginDto userDto)
        {
            var user = userRepository.GetByUserName(userDto.UserName);
           if(user==null )
                return new ServiceResult<UserLoginResultDto>(ResultStatusCode.LogicError, false, message: "کاربری با این نام کاربری یافت نشد");
           
            if(user.Password!=userDto.Password)
                return new ServiceResult<UserLoginResultDto>(ResultStatusCode.LogicError, false, message: "کلمه عبور نادرست است");

            var userAccessToken=userRepository.GetUserAccessToken(user.Id);
            TokenResultDto token;

            if (userAccessToken == null)
            {
                //ساخت توکن
                token = tokenGenerateService.Handle(new UserTokenDto { UserId = user.Id }).Result;

                //دخیره توکن
                userRepository.StoreAccessToken(user.Id, token.Token);

                unitOfWork.Commit();
            }
            else
                token = new TokenResultDto() { Token = userAccessToken.Token };

            cacheProviderService.Set(CacheNameSpace.UserAccessToken,token.Token, user.Id);
            cacheProviderService.Set(CacheNameSpace.User,user.Id.ToString(), new UserInfoResultDto
            {
                Id = user.Id,
                UserName = user.UserName,
                UserGroup = user.UserGroup,
                FullName = $"{user.FirstName} {user.LastName}",
                CollegeId=user.CollegeId,
                CollegeName=user.College?.CollegeName,
                UserGroupName=user.UserGroup.ToDisplay()
            });

            return new ServiceResult<UserLoginResultDto>(ResultStatusCode.Success, true, result: new UserLoginResultDto {UserGroup=user.UserGroup, AccessToken=token.Token});            
        }
    }
}
