using Blog.Domain.Core.Contact.IAppServices;
using Blog.Domain.Core.Contact.IServices;
using Microsoft.AspNetCore.Http;

namespace Blog.Domain.AppServices
{
    public class FileAppService: IFileAppService
    {
        private readonly IFileService fileService;

        public FileAppService(IFileService FileService)
        {
            fileService = FileService;
        }
        public string Upload(IFormFile file, string folder)
        {
            return fileService.Upload(file, folder);
        }
    }
}
