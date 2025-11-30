using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos.CommentDtos;
using Blog.Domain.Core.Entities;
using Blog.Infra.Db.AppDb;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.DA.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly AppDbContext appDbContext;

        public CommentRepository(AppDbContext AppDbContext)
        {
            appDbContext = AppDbContext;
        }
        public int Add(Comment comment)
        {
            appDbContext.Comments.Add(comment);
            appDbContext.SaveChanges();
            return comment.Id;
        }
        public List<ShowManagementCommentDto> GetAllCommentUser(int userid)
        {
            return appDbContext.Comments
                .Where(c => c.Post.UserId == userid)
                .OrderByDescending(c=>c.CreateAt)
                .Select(c => new ShowManagementCommentDto
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    FullName = c.User.FullName,
                    PostTitle = c.Post.Title,
                    Score = c.Score,
                    Text = c.Text,
                    UserEmail = c.User.Email,
                }).ToList();
        }
        public List<ShowPostComment> GetPostComments(int postid)
        {
            return appDbContext.Comments
                .Where(c=>c.PostId == postid&&c.IsActive==true)
                .Select(c=>new ShowPostComment
            {
                    FullName = c.User.FullName,
                    Score = c.Score,
                    Text= c.Text,
                    UserEmail= c.User.Email,
            }).ToList();
        } 
        public void ActivateComment(int id)
        {
            appDbContext.Comments
                .Where(c=>c.Id==id)
                .ExecuteUpdate(setter=>setter
                .SetProperty(c=>c.IsActive,true));
        }
        public bool ExistComment(int id)
        {
           return appDbContext.Comments.Any(c=>c.Id==id);
        }
    }
}
