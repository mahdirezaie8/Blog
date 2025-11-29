using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.PostDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Core.Contact.IServices
{
    public interface IPostService
    {
        public ResultDto<bool> CreatePost(CreatePostDto createPostDto);
        public ResultDto<bool> Delete(int postid);
        public ResultDto<List<ShowPostDto>> GetAllPostUser(int userid);
        public ResultDto<ShowUpdatePostDto> GetPost(int postid);
        public ResultDto<bool> UpdatePost(UpdatePostDto updatePostDto, int postid);
        public ResultDto<List<ShowPostDto>> GetAllPost(string categorytitle);
        public ResultDto<ShowPostDto> GetPostUserById(int postid);
    }
}
