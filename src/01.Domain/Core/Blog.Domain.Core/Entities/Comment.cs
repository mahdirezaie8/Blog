using Blog.Domain.Core.Enums;

namespace Blog.Domain.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ScoreEnum Score { get; set; }
        public bool IsActive { get; set; }=false;
        public Post Post { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
