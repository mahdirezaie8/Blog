using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Dtos.PostDtos;
using Blog.EndPoint.MVC.Extentions;
using Blog.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Blog.EndPoint.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostAppService postAppService;
        private readonly ICookieService cookieService;
        private readonly ICategoryAppService categoryAppService;
        private readonly ICommentAppService commentAppService;

        public PostController(IPostAppService PostAppService
            ,ICookieService CookieService
            ,ICategoryAppService CategoryAppService,ICommentAppService CommentAppService)
        {
            postAppService = PostAppService;
            cookieService = CookieService;
            categoryAppService = CategoryAppService;
            commentAppService = CommentAppService;
        }
        public IActionResult Management()
        {
            var userid=cookieService.GetUserId();
            var posts = postAppService.GetAllPostUser(userid);
            return View(posts.Data);
        }
        public IActionResult Create()
        {
            var userid = cookieService.GetUserId();
            var categories = categoryAppService.GetUserCategories(userid);
            ViewBag.Categories=categories.Data;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePostViewModel createPostViewModel)
        {
            var userid = cookieService.GetUserId();
            var dto = new CreatePostDto()
            {
                CategoryId = createPostViewModel.CategoryId,
                ProfileImage = createPostViewModel.ProfileImage,
                Description = createPostViewModel.Description,
                Title = createPostViewModel.Title,
                UserId = userid,
            };
            var create=postAppService.CreatePost(dto);
            if(create.IsSuccess)
            {
                return RedirectToAction("Management");
            }
            else
            {
                TempData["Error"]=create.Message;
                return RedirectToAction("Create");
            }
        }
        public IActionResult Update(int id)
        {
            var userid = cookieService.GetUserId();
            var categories = categoryAppService.GetUserCategories(userid);
            ViewBag.Categories = categories.Data;
            var post=postAppService.GetPost(id);
            return View(post.Data);
        }
        [HttpPost]
        public IActionResult Update(UpdatePostDto updatePostDto, int id)
        {
            var update=postAppService.UpdatePost(updatePostDto,id);
            if(update.IsSuccess)
            {
                return RedirectToAction("Management");
            }
            else
            {
                TempData["Error"]=update.Message;
                return RedirectToAction("Update");
            }
        }
        public IActionResult Delete(int id)
        {
            var delete = postAppService.Delete(id);
            if(delete.IsSuccess)
            {
                return RedirectToAction("Management");
            }
            else
            {
                TempData["Error"] = delete.Message;
                return RedirectToAction("Management");
            }
        }
        public IActionResult Details(int id)
        {
            var post=postAppService.GetPostUserById(id);
            if(post.IsSuccess)
            {
                var comments = commentAppService.GetPostComment(id);
                TempData["Comments"] = comments.Data;
                return View(post.Data);
            }
            else
            {
                TempData["Error"] = post.Message;
                return View();
            }
        }
    }
}
