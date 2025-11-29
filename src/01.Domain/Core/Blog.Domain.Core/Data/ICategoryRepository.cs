using Blog.Domain.Core.Dtos.CategoryDtos;
using Blog.Domain.Core.Entities;
using System;

namespace Blog.Domain.Core.Data
{
    public interface ICategoryRepository
    {
        public int Add(Category category);
        public void Update(int categoryid, string newtitle);
        public void Delete(int categoryid);
        public List<ShowCategoriesDto> GetUserCategories(int userid);
        public bool ExistCategoryById(int id);
        public ShowCategoriesDto? GetCategoryById(int id);
        public bool ExistCategoryByTitle(string title);
    }
}
