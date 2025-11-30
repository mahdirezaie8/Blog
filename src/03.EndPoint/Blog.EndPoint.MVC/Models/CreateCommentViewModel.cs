using Blog.Domain.Core.Enums;

namespace Blog.EndPoint.MVC.Models
{
    public class CreateCommentViewModel
    {
        public string Text { get; set; }
        public ScoreEnum Score { get; set; }
        public int PostId { get; set; }
    }
}
