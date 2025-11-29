using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Dtos.CategoryDtos;
using Blog.EndPoint.MVC.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.EndPoint.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService categoryAppService;
        private readonly ICookieService cookieService;

        public CategoryController(ICategoryAppService categoryappService, ICookieService cookieservice)
        {
            categoryAppService = categoryappService;
            cookieService = cookieservice;
        }
        public IActionResult Index()
        {
            var userid = cookieService.GetUserId();
            var categories = categoryAppService.GetUserCategories(userid);
            ViewBag.Error = categories.Message;
            return View(categories.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Title)
        {
            var userid = cookieService.GetUserId();
            var newcategorydto = new CreateCategoryDto
            {
                Title = Title,
                UserId = userid,
            };
            var create = categoryAppService.CreateCategory(newcategorydto);
            if (create.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error=create.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var category = categoryAppService.GetCategoryDtoById(id);
            if (category.IsSuccess)
            {
                return View(category.Data);
            }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(int id,string title)
        {
            var updade=categoryAppService.Update(id,title);
            if (updade.IsSuccess) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error=updade.Message;
                var category = categoryAppService.GetCategoryDtoById(id);
                return View(category.Data);
            }
        }
        public IActionResult Delete(int id)
        {
            var delete=categoryAppService.Delete(id);
            if (delete.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error=delete.Message;
                var userid = cookieService.GetUserId();
                var categories = categoryAppService.GetUserCategories(userid);
                return View(categories.Data);
            }
        }
    }
}
