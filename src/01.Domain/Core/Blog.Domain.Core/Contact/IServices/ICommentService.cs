using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CommentDtos;

namespace Blog.Domain.Core.Contact.IServices
{
    public interface ICommentService
    {
        public ResultDto<bool> CreateComment(CreateComment createComment);
        public ResultDto<List<ShowManagementCommentDto>> CommentManagement(int userid);
        public ResultDto<List<ShowPostComment>> GetPostComment(int postid);
        public ResultDto<bool> ActivateComment(int commentId);
    }
}
