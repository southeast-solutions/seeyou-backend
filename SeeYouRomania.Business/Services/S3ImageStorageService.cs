using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Domain.AWS;
using Domain.Contracts;
using Domain.Request.Other;
using Domain.Response.Other;

namespace Business.Services
{
    public class S3ImageStorageService : IImageStorageService
    {
        private readonly IAmazonS3 s3;
        private readonly AwsEnvironment awsEnvironment;

        public S3ImageStorageService(IAmazonS3 s3, AwsEnvironment awsEnvironment)
        {
            this.s3 = s3;
            this.awsEnvironment = awsEnvironment;
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
                ContentType = request.DataFile.ContentType,
                Key = key
            };
            
            try
            {
                await s3.PutObjectAsync(putObjectRequest);
                uploadImageResponse.Url = GetUrlForKey(bucket, key);
            }
            catch (Exception)
            {
                uploadImageResponse.Success = false;
            }

            return uploadImageResponse;
        }

        private string GetUrlForKey(string bucket, string key)
        {
            return $"https://{bucket}.s3.{awsEnvironment.Region}.amazonaws.com/{key}";
        }
    }
}