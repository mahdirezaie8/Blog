using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos.CategoryDtos;
using Blog.Domain.Core.Entities;
using Blog.Infra.Db.AppDb;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.DA.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext AppDbContext)
        {
            appDbContext = AppDbContext;
        }
        public int Add(Category category)
        {
            appDbContext.Categories.Add(category);
            appDbContext.SaveChanges();
            return category.Id;
        }
        public void Update(int categoryid,string newtitle)
        {
            appDbContext.Categories
                .Where(c=>c.Id==categoryid)
                .ExecuteUpdate(setter=>setter
                .SetProperty(c=>c.Title,newtitle));
        }
        public void Delete(int categoryid)
        {
            appDbContext.Categories.Where(c=>c.Id==categoryid).ExecuteDelete();
        }
        public List<ShowCategoriesDto> GetUserCategories(int userid)
        {
            return appDbContext.Categories
                .Where(c=>c.UserId==userid)
                .Select(c=>new ShowCategoriesDto
            {
                    Id= c.Id,
                Title = c.Title,
            }).ToList();
        }
        public bool ExistCategoryById(int id)
        {
            return appDbContext.Categories.Any(c=>c.Id==id);  
        }
        public ShowCategoriesDto? GetCategoryById(int id)
        {
            return appDbContext.Categories
                .Select(c => new ShowCategoriesDto
                {
                    Id = c.Id,
                    Title = c.Title,
                }).FirstOrDefault(c => c.Id == id);
        }
        public bool ExistCategoryByTitle(string title)
        {
           return appDbContext.Categories.Any(c=>c.Title.ToLower()==title.ToLower());
        }
    }
}
