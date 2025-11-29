using Blog.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Core.Dtos.PostDtos
{
    public class ShowUpdatePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ProfileImage { get; set; }
        public string CategoryTitle { get; set; }
    }
}
