using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CommentDtos;

namespace Blog.Domain.AppServices
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService commentService;

        public CommentAppService(ICommentService CommentService)
        {
            commentService = CommentService;
        }
        public ResultDto<bool> ActivateComment(int commentId)
        {
            return commentService.ActivateComment(commentId);
        }

        public ResultDto<List<ShowManagementCommentDto>> CommentManagement(int userid)
        {
            return commentService.CommentManagement(userid);
        }

        public ResultDto<bool> CreateComment(CreateComment createComment)
        {
            return commentService.CreateComment(createComment);
        }

        public ResultDto<List<ShowPostComment>> GetPostComment(int postid)
        {
            return commentService.GetPostComment(postid);
        }
    }
}
