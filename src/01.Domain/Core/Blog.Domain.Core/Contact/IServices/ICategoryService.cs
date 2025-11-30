using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CategoryDtos;

namespace Blog.Domain.Core.Contact.IServices
{
    public interface ICategoryService
    {
        public ResultDto<bool> CreateCategory(CreateCategoryDto createCategoryDto);
        public ResultDto<bool> Update(int categoryid, string newtitle);
        public ResultDto<bool> Delete(int categoryid);
        public ResultDto<List<ShowCategoriesDto>> GetUserCategories(int userid);
        public ResultDto<ShowCategoriesDto> GetCategoryDtoById(int categoryid);
    }
}
