using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CommentDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Services
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository CommentRepository)
        {
            _commentRepository = CommentRepository;
        }
        public ResultDto<bool> CreateComment(CreateComment createComment)
        {
            if(string.IsNullOrEmpty(createComment.Text))
            {
                return ResultDto<bool>.Failure("لطفا فیلد هارو پر کنید.");
            }
            else
            {
                var newcomment = new Comment
                {
                    Text = createComment.Text,
                    CreateAt = DateTime.Now,
                    PostId = createComment.PostId,
                    Score = createComment.Score,
                    UserId = createComment.UserId,
                };
                var id=_commentRepository.Add(newcomment);
                return ResultDto<bool>.Success("success");
            }
        }
        public ResultDto<List<ShowManagementCommentDto>> CommentManagement(int userid)
        {
            var comment = _commentRepository.GetAllCommentUser(userid);
            if (comment.Count > 0)
            {
                return ResultDto<List<ShowManagementCommentDto>>.Success("success",comment);
            }
            else
                return ResultDto<List<ShowManagementCommentDto>>.Failure("کامنتی وجود ندارد.");
        }
        public ResultDto<List<ShowPostComment>> GetPostComment(int postid)
        {
            var comments=_commentRepository.GetPostComments(postid);
            if (comments.Count > 0)
            {
                return ResultDto<List<ShowPostComment>>.Success("success", comments);
            }
            else
                return ResultDto<List<ShowPostComment>>.Failure("این پست کامنتی ندارد.");
        }
        public ResultDto<bool> ActivateComment(int commentId)
        {
            var exist=_commentRepository.ExistComment(commentId);
            if (exist)
            {
                _commentRepository.ActivateComment(commentId);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("کامن پیدا نشد.");
        }
    }
}
