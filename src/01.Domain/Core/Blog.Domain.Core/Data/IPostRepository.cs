using Blog.Domain.Core.Dtos.PostDtos;
using Blog.Domain.Core.Entities;
using System;

namespace Blog.Domain.Core.Data
{
    public interface IPostRepository
    {
        public int Add(Post post);
        public void Update();
        public List<ShowPostDto> GetShowPostsUsers(int userid);
        public void Delete(int id);
        public bool ExistPostById(int id);
        public ShowUpdatePostDto? ShowPostForUpdate(int postid);
        public Post? GetPostByID(int id);
        public List<ShowPostDto> GetAllPost(string categorytitle);
        public ShowPostDto? GetPostUserById(int id);
    }
}
