using Blog.Domain.Core.Entities;

namespace Blog.Domain.Core.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
