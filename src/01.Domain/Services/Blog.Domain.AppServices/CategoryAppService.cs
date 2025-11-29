using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CategoryDtos;

namespace Blog.Domain.AppServices
{
    public class CategoryAppService: ICategoryAppService
    {
        private readonly ICategoryService categoryService;

        public CategoryAppService(ICategoryService categoryservice)
        {
            categoryService = categoryservice;
        }
        public ResultDto<bool> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            return categoryService.CreateCategory(createCategoryDto);
        }
        public ResultDto<bool> Update(int categoryid, string newtitle)
        {
            return categoryService.Update(categoryid, newtitle);

        }
        public ResultDto<bool> Delete(int categoryid)
        {
            return categoryService.Delete(categoryid);
        }
        public ResultDto<List<ShowCategoriesDto>> GetUserCategories(int userid)
        {
            return categoryService.GetUserCategories(userid);
        }
        public ResultDto<ShowCategoriesDto> GetCategoryDtoById(int categoryid)
        {
            return categoryService.GetCategoryDtoById(categoryid);
        }
    }
}
