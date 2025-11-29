namespace Blog.Domain.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; } = [];
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
