using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.UserDtos;

namespace Blog.Domain.Core.Contact.IServices
{
    public interface IUserService
    {
        public ResultDto<UserDto> Login(string username, string password);
        public ResultDto<bool> Register(UserRegisterDto userRegisterDto);
    }
}
