using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Dtos.UserDtos;
using Blog.EndPoint.MVC.Extentions;
using Blog.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.EndPoint.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly ICookieService cookieService;

        public AccountController(IUserAppService UserAppService,ICookieService cookieservice)
        {
            userAppService = UserAppService;
          cookieService = cookieservice;
        }
        public IActionResult Login()
        {
            if (cookieService.UserIsLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = userAppService.Login(loginViewModel.UserName, loginViewModel.Password);
            if (user.IsSuccess)
            {
                cookieService.Set("Id", user.Data.Id.ToString());
                cookieService.Set("Username", user.Data.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = user.Message;
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var register = userAppService.Register(userRegisterDto);
            if (register.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = register.Message;
                return View();
            }
        }
        public IActionResult Logout()
        {
            cookieService.Delete("Id");
            cookieService.Delete("Username");
            return RedirectToAction("Login");
        }
    }
}
