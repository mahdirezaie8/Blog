using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.CategoryDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryrepository)
        {
           categoryRepository = categoryrepository;
        }
        public ResultDto<bool> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (!string.IsNullOrEmpty(createCategoryDto.Title))
            {
                var newcategory = new Category()
                {
                    Title = createCategoryDto.Title,
                    UserId = createCategoryDto.UserId,
                };
                var categoryid = categoryRepository.Add(newcategory);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("لطفا عنوان را پر کنید.");
        }
        public ResultDto<bool> Update(int categoryid, string newtitle)
        {
            if (!string.IsNullOrEmpty(newtitle))
            {
                var exist = categoryRepository.ExistCategoryById(categoryid);
                if (exist)
                {
                    var titleExist=categoryRepository.ExistCategoryByTitle(newtitle);
                    if (titleExist)
                    {
                        return ResultDto<bool>.Failure("این عنوان تکراری است.");
                    }
                    else
                    {
                        categoryRepository.Update(categoryid, newtitle);
                        return ResultDto<bool>.Success("success");
                    }
                }
                else
                    return ResultDto<bool>.Failure("کتگوری پیدا نشد.");
            }
            else
                return ResultDto<bool>.Failure("لطفا عنوان را پر کنید.");
        }
        public ResultDto<bool> Delete(int categoryid)
        {
            var exist = categoryRepository.ExistCategoryById(categoryid);
            if (exist)
            {
                categoryRepository.Delete(categoryid);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("کتگوری پیدا نشد.");
        }
        public ResultDto<List<ShowCategoriesDto>> GetUserCategories(int userid)
        {
            var categories=categoryRepository.GetUserCategories(userid);
            if (categories.Count > 0)
            {
                return ResultDto<List<ShowCategoriesDto>>.Success("success", categories);
            }
            else
                return ResultDto<List<ShowCategoriesDto>>.Failure("شما هیچ کتگوری ندارید.");
        }
        public ResultDto<ShowCategoriesDto> GetCategoryDtoById(int categoryid)
        {
            var category=categoryRepository.GetCategoryById(categoryid);
            if (category == null)
            {
                return ResultDto<ShowCategoriesDto>.Failure("این دسته بندی پیدا نشد.");
            }
            else
                return ResultDto<ShowCategoriesDto>.Success("success", category);
        }
    }
}
