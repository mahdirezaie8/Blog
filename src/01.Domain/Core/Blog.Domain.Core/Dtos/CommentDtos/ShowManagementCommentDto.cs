using Blog.Domain.Core.Enums;

namespace Blog.Domain.Core.Dtos.CommentDtos
{
    public class ShowManagementCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ScoreEnum Score { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string PostTitle { get; set; }
    }
}
