using Blog.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Core.Dtos.PostDtos
{
    public class ShowPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Profile { get; set; }
        public string CategoryTitle { get; set; }
    }
}
