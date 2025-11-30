using Blog.Domain.Core.Dtos.CommentDtos;
using Blog.Domain.Core.Entities;
using System;

namespace Blog.Domain.Core.Data
{
    public interface ICommentRepository
    {
        public int Add(Comment comment);
        public List<ShowManagementCommentDto> GetAllCommentUser(int userid);
        public List<ShowPostComment> GetPostComments(int postid);
        public void ActivateComment(int id);
        public bool ExistComment(int id);
    }
}
