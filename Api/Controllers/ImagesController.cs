using System.Threading.Tasks;
using Domain.AWS;
using Domain.Contracts;
using Domain.Request.Other;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageStorageService imageStorageService;
        private readonly BucketConfig bucketConfig;

        public ImagesController(IImageStorageService imageStorageService, BucketConfig bucketConfig)
        {
            this.imageStorageService = imageStorageService;
            this.bucketConfig = bucketConfig;
        }

        [HttpPost("profile")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] UploadImageRequest request)
        {
            var res = await imageStorageService.UploadImage(request, bucketConfig.GetProfilePicturesBucket());

            return Created(nameof(UploadProfilePicture), res);
        }
        
        [HttpPost("experience")]
        public async Task<IActionResult> UploadExperienceImage([FromForm] UploadImageRequest request)
        {
            var res = await imageStorageService.UploadImage(request, bucketConfig.GetExperienceImagesBucket());

            return Created(nameof(UploadExperienceImage), res);
        }
    }
}