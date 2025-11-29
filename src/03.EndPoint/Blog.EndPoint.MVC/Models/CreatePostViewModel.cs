namespace Blog.EndPoint.MVC.Models
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int CategoryId { get; set; }
    }
}
