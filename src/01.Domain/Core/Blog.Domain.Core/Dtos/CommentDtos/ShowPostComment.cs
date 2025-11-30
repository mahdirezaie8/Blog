using Blog.Domain.Core.Enums;

namespace Blog.Domain.Core.Dtos.CommentDtos
{
    public class ShowPostComment
    {
        public string Text { get; set; }
        public ScoreEnum Score { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
    }
}
