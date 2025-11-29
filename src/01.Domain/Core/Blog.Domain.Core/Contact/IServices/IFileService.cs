using Microsoft.AspNetCore.Http;

namespace Blog.Domain.Core.Contact.IServices
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
    }
}
