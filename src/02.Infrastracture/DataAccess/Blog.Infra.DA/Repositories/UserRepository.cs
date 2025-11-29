using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos.UserDtos;
using Blog.Domain.Core.Entities;
using Blog.Infra.Db.AppDb;

namespace Blog.Infra.DA.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Add(User noperator)
        {
            _appDbContext.Users.Add(noperator);
            _appDbContext.SaveChanges();
            return noperator.Id;
        }
        public UserDto? GetUser(string username, string password)
        {
            return _appDbContext.Users
                .Where(o => o.Username == username
                && password == o.Password).Select(o => new UserDto
                {
                    Id = o.Id,
                    Username = o.Username,
                }).FirstOrDefault();
        }
        public bool ExistUserByUsername(string username)
        {
            return _appDbContext.Users.Any(o => o.Username == username);
        }
    }
}
