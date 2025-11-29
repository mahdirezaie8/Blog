using Microsoft.AspNetCore.Http;

namespace Blog.Domain.Core.Contact.IAppServices
{
    public interface IFileAppService
    {
        public string Upload(IFormFile file, string folder);
    }
}
