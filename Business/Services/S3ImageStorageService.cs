using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Domain.Contracts;
using Domain.Request.Other;
using Domain.Response.Other;

namespace Business.Services
{
    public class S3ImageStorageService : IImageStorageService
    {
        private readonly AmazonS3Client s3;

        public S3ImageStorageService(AmazonS3Client s3)
        {
            this.s3 = s3;
        }

        public async Task<UploadImageResponse> UploadImage(UploadImageRequest request, string bucket)
        {
            string key = Guid.NewGuid().ToString();

            UploadImageResponse uploadImageResponse = new UploadImageResponse()
            {
                Success = true
            };

            var putObjectRequest = new PutObjectRequest()
            {
                BucketName = bucket,
                InputStream = request.DataFile.OpenReadStream(),
                ContentType = "image/jpg",
                Key = key
            };

            try
            {
                await s3.PutObjectAsync(putObjectRequest).ConfigureAwait(false);
                uploadImageResponse.Key = key;
            }
            catch (Exception)
            {
                uploadImageResponse.Success = false;
            }

            return uploadImageResponse;
        }
    }
}