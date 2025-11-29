using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.UserDtos;

namespace Blog.Domain.Core.Contact.IAppServices
{
    public interface IUserAppService
    {
        public ResultDto<UserDto> Login(string username, string password);
        public ResultDto<bool> Register(UserRegisterDto userRegisterDto);
    }
}
