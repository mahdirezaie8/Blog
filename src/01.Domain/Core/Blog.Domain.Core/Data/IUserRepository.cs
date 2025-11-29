using Blog.Domain.Core.Dtos.UserDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Core.Data
{
    public interface IUserRepository
    {
        public int Add(User noperator);
        public UserDto? GetUser(string username, string password);
        public bool ExistUserByUsername(string username);
    }
}
