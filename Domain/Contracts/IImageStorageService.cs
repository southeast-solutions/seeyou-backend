using System.Threading.Tasks;
using Domain.Request.Other;
using Domain.Response.Other;

namespace Domain.Contracts
{
    public interface IImageStorageService
    {
        Task<UploadImageResponse> UploadImage(UploadImageRequest request, string bucket);
    }
}