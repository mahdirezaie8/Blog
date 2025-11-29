using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.PostDtos;

namespace Blog.Domain.AppServices
{
    public class PostAppService:IPostAppService
    {
        private readonly IPostService postService;

        public PostAppService(IPostService PostService)
        {
            postService = PostService;
        }
        public ResultDto<bool> CreatePost(CreatePostDto createPostDto)
        {
            return postService.CreatePost(createPostDto);
        }
        public ResultDto<bool> Delete(int postid)
        {
            return postService.Delete(postid);
        }
        public ResultDto<List<ShowPostDto>> GetAllPostUser(int userid)
        {
            return postService.GetAllPostUser(userid);
        }

        public ResultDto<ShowUpdatePostDto> GetPost(int postid)
        {
            return postService.GetPost(postid);
        }
        public ResultDto<bool> UpdatePost(UpdatePostDto updatePostDto, int postid)
        {
            return postService.UpdatePost(updatePostDto, postid);
        }
        public ResultDto<List<ShowPostDto>> GetAllPost(string categorytitle)
        {
            return postService.GetAllPost(categorytitle);
        }
        public ResultDto<ShowPostDto> GetPostUserById(int postid)
        {
            return postService.GetPostUserById(postid);
        }
    }
}
