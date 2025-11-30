using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; } = [];
    }
}
