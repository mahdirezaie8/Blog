using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Blog.Domain.Core.Data;
using Blog.Domain.Core.Dtos;
using Blog.Domain.Core.Dtos.PostDtos;
using Blog.Domain.Core.Entities;

namespace Blog.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IFileAppService fileAppService;

        public PostService(IPostRepository postRepository, IFileAppService fileappService)
        {
            _postRepository = postRepository;
            fileAppService = fileappService;
        }
        public ResultDto<bool> CreatePost(CreatePostDto createPostDto)
        {
            if (string.IsNullOrEmpty(createPostDto.Title)
                && string.IsNullOrEmpty(createPostDto.Description))
            {
                return ResultDto<bool>.Failure("لطفا فیلد هارو پر کنید");
            }
            else
            {
                string image = null;
                if (createPostDto.ProfileImage != null)
                {
                    image = fileAppService.Upload(createPostDto.ProfileImage, "Img");
                }
                var newpost = new Post
                {
                    Title = createPostDto.Title,
                    Description = createPostDto.Description,
                    Image = image,
                    CategoryId = createPostDto.CategoryId,
                    CreateAt = DateTime.Now,
                    UserId = createPostDto.UserId,
                };
                var id = _postRepository.Add(newpost);
                return ResultDto<bool>.Success("create is success");
            }
        }
        public ResultDto<bool> Delete(int postid)
        {
            var exist = _postRepository.ExistPostById(postid);
            if (exist)
            {
                _postRepository.Delete(postid);
                return ResultDto<bool>.Success("success");
            }
            else
                return ResultDto<bool>.Failure("پست پیدا نشد.");
        }
        public ResultDto<List<ShowPostDto>> GetAllPostUser(int userid)
        {
            var posts=_postRepository.GetShowPostsUsers(userid);
            if(posts.Count > 0)
            {
                return ResultDto<List<ShowPostDto>>.Success("success",posts);
            }
            else
            {
                return ResultDto<List<ShowPostDto>>.Failure("شما پستی ندارید.");
            }
        }
        public ResultDto<ShowUpdatePostDto> GetPost(int postid)
        {
            var post=_postRepository.ShowPostForUpdate(postid);
            if (post == null)
            {
                return ResultDto<ShowUpdatePostDto>.Failure("پست پیدا نشد.");
            }
            else
                return ResultDto<ShowUpdatePostDto>.Success("success", post);
        }
        public ResultDto<bool> UpdatePost(UpdatePostDto updatePostDto, int postid)
        {
            var post=_postRepository.GetPostByID(postid);
            if(post == null)
            {
                return ResultDto<bool>.Failure("پست پیدا نشد.");
            }
            else
            {
                if (!string.IsNullOrEmpty(updatePostDto.Title))
                {
                    post.Title = updatePostDto.Title;
                }
                if (!string.IsNullOrEmpty(updatePostDto.Description))
                {
                    post.Description = updatePostDto.Description;
                }
                if (updatePostDto.ProfileImage != null)
                {
                    post.Image = fileAppService.Upload(updatePostDto.ProfileImage, "Img");
                }
                if(updatePostDto.CategoryId != null)
                {
                    post.CategoryId = updatePostDto.CategoryId.Value;
                }
                _postRepository.Update();
                return ResultDto<bool>.Success("success");
            }
        }
        public ResultDto<List<ShowPostDto>> GetAllPost(string categorytitle)
        {
            var posts=_postRepository.GetAllPost(categorytitle);
            if (posts.Count > 0)
            {
                return ResultDto<List<ShowPostDto>>.Success("success",posts);
            }
            else
            {
                return ResultDto<List<ShowPostDto>>.Failure("پستی یافت نشد.");
            }
        }
        public ResultDto<ShowPostDto> GetPostUserById(int postid)
        {
            var post = _postRepository.GetPostUserById(postid);
            if (post == null)
            {
                return ResultDto<ShowPostDto>.Failure("پست پیدا نشد.");
            }
            else
                return ResultDto<ShowPostDto>.Success("success", post);
        }
    }
}
