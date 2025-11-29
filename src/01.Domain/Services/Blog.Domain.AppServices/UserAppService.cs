using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.UserDtos;

namespace Blog.Domain.AppServices
{
    public class UserAppService:IUserAppService
    {
        private readonly IUserService userService;

        public UserAppService(IUserService UserService)
        {
            userService = UserService;
        }
        public ResultDto<UserDto> Login(string username, string password)
        {
      return userService.Login(username, password);
        }
        public ResultDto<bool> Register(UserRegisterDto userRegisterDto)
        {
            return userService.Register(userRegisterDto);
        }
    }
}
