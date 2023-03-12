using Amazon.S3.Model;

namespace AmazonS3Example.API.Infrastructure.Services.S3;

public interface IImageService
{
    Task<GetObjectResponse> GetImage(Guid id);
    Task<PutObjectResponse> UploadImage(Guid id, IFormFile file);
    Task<DeleteObjectResponse> DeleteImage(Guid id);
}