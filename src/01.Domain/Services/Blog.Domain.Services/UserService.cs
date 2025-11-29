using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.UserDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository Repository)
        {
            _repository = Repository;
        }
        public ResultDto<UserDto> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return ResultDto<UserDto>.Failure("لطفا فیلد هارا پر کنید.");
            }
            else
            {
                var op = _repository.GetUser(username, password);
                if (op == null)
                {
                    return ResultDto<UserDto>.Failure("یوزر پیدا نشد");
                }
                else
                {
                        return ResultDto<UserDto>.Success("لاگین با موفقیت انجام شد.", op);
                }
            }
        }
        public ResultDto<bool> Register(UserRegisterDto userRegisterDto)
        {
            if (string.IsNullOrEmpty(userRegisterDto.FullName)
                && string.IsNullOrEmpty(userRegisterDto.Username)
                && string.IsNullOrEmpty(userRegisterDto.Password)
                &&string.IsNullOrEmpty(userRegisterDto.Email))
            {
                return ResultDto<bool>.Failure("فیلد هارو کامل پر کنید.");
            }
            else
            {
                if (userRegisterDto.Username.Count() > 6 && userRegisterDto.Password.Count() > 6)
                {
                    if (userRegisterDto.Email.Contains("@"))
                    {
                        var existuser = _repository.ExistUserByUsername(userRegisterDto.Username);
                        if (existuser)
                        {
                            return ResultDto<bool>.Failure("این یوزرنیم توسط شخص دیگری انتخاب شده است.");
                        }
                        else
                        {
                            var newop = new User
                            {
                                FullName = userRegisterDto.FullName,
                                Username = userRegisterDto.Username,
                                Password = userRegisterDto.Password,
                                Email= userRegisterDto.Email,
                                PhoneNumber= userRegisterDto.PhoneNumber,
                            };
                            var opid = _repository.Add(newop);
                            return ResultDto<bool>.Success("ثبت نام با موفقیت انجام شد.");
                        }
                    }
                    else
                        return ResultDto<bool>.Failure("ایمیل نامعتبر است.");
                }
                else
                {
                    return ResultDto<bool>.Failure("تعداد کاراکتر های پسوورد و یوزرنیم بیشتر از 6 تا باشد.");
                }
            }
        }
    }
}
