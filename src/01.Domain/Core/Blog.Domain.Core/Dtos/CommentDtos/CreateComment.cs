using Blog.Domain.Core.Entities;
using Blog.Domain.Core.Enums;

namespace Blog.Domain.Core.Dtos.CommentDtos
{
    public class CreateComment
    {
        public string Text { get; set; }
        public ScoreEnum Score { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
