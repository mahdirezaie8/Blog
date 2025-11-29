using Blog.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Core.Dtos.PostDtos
{
    public class UpdatePostDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int? CategoryId { get; set; }
    }
}
