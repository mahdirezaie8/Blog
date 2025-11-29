using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos.CategoryDtos;
using Blog.Domain.Core.Dtos.PostDtos;
using Blog.Domain.Core.Entities;
using Blog.Infra.Db.AppDb;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.DA.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly AppDbContext appDbContext;
        public PostRepository(AppDbContext AppDbContext)
        {
            appDbContext = AppDbContext;
        }
        public int Add(Post post)
        {
            appDbContext.Posts.Add(post);
            appDbContext.SaveChanges();
            return post.Id;
        }
        public void Update()
        {
            appDbContext.SaveChanges();
        }
        public List<ShowPostDto> GetShowPostsUsers(int userid)
        {
            return appDbContext.Posts
                .Where(p=>p.UserId == userid)
                .Select(p=>new ShowPostDto
            {
                Id = p.Id,
                Profile=p.Image,
                CategoryTitle=p.Category.Title,
                CreateAt=p.CreateAt,
                Description=p.Description,
                Title=p.Title,
            }).ToList();
        }
        public void Delete(int id)
        {
            appDbContext.Posts
                .Where(p=>p.Id==id).ExecuteDelete();
        }

        public bool ExistPostById(int id)
        {
            return appDbContext.Posts.Any(p=>p.Id==id);
        }
        public ShowUpdatePostDto? ShowPostForUpdate(int postid)
        {
            return appDbContext.Posts.Where(p => p.Id == postid).Select(p => new ShowUpdatePostDto
            {
                Id=p.Id,
                CategoryTitle = p.Category.Title,
                Description = p.Description,
                Title = p.Title,
                ProfileImage=p.Image,
            }).FirstOrDefault();
        }
        public Post? GetPostByID(int id)
        {
            return appDbContext.Posts.FirstOrDefault(p=>p.Id==id);
        }
        public List<ShowPostDto> GetAllPost(string categorytitle)
        {
            var posts= appDbContext.Posts.Select(p => new ShowPostDto
            {
                Id = p.Id,
                CategoryTitle = p.Category.Title,
                Description = p.Description,
                Title = p.Title,
                Profile = p.Image,
                CreateAt = p.CreateAt,
            }).AsQueryable();
            if (!string.IsNullOrEmpty(categorytitle))
            {
                posts = posts.Where(p => p.CategoryTitle.Contains(categorytitle));
            }
            return posts.OrderByDescending(p=>p.CreateAt).ToList();
        }
        public ShowPostDto? GetPostUserById(int id)
        {
            return appDbContext.Posts.Where(p => p.Id == id).Select(p => new ShowPostDto
            {
                Id = p.Id,
                Profile = p.Image,
                CreateAt = p.CreateAt,
                CategoryTitle = p.Category.Title,
                Description = p.Description,
                Title = p.Title,
            }).FirstOrDefault();
        }
    }
}
