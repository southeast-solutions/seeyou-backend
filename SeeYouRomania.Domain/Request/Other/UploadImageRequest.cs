using Microsoft.AspNetCore.Http;

namespace Domain.Request.Other
{
    public class UploadImageRequest
    {
        public IFormFile DataFile;
    }
}