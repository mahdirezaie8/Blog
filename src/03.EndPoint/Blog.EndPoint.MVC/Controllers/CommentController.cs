using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Dtos.CommentDtos;
using Blog.Domain.Core.Entities;
using Blog.EndPoint.MVC.Extentions;
using Blog.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.EndPoint.MVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentAppService commentAppService;
        private readonly ICookieService cookieService;

        public CommentController(ICommentAppService CommentAppService, ICookieService CookieService)
        {
            commentAppService = CommentAppService;
            cookieService = CookieService;
        }
        public IActionResult Index()
        {
            var userid = cookieService.GetUserId();
            var comment = commentAppService.CommentManagement(userid);
            return View(comment.Data);
        }
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCommentViewModel createComment)
        {
            var userid = cookieService.GetUserId();
            var createdto = new CreateComment
            {
                PostId = createComment.PostId,
                Score = createComment.Score,
                Text = createComment.Text,
                UserId = userid
            };
            var newcomment = commentAppService.CreateComment(createdto);
            if (newcomment.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = newcomment.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var success = commentAppService.ActivateComment(id);
            if (!success.IsSuccess)
            {
                TempData["Error"] = success.Message;
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
    }
}
