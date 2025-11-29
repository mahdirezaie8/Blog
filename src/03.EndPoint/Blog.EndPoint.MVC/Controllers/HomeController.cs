using Blog.Domain.Core.Contact.IAppServices;
using Microsoft.AspNetCore.Mvc;

namespace Blog.EndPoint.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppService postAppService;

        public HomeController(IPostAppService PostAppService)
        {
            postAppService = PostAppService;
        }
        public IActionResult Index(string categorytitle)
        {
            var posts = postAppService.GetAllPost(categorytitle);
            return View(posts.Data);
        }
    }
}
