using Amazon.S3;
using Amazon.S3.Model;

namespace AmazonS3Example.API.Infrastructure.Services.S3;

public class ImageService : IImageService
{
    private const string BucketName = "vsv-aws-fundamentals";

    private readonly IAmazonS3 _s3;

    public ImageService(IAmazonS3 s3)
    {
        _s3 = s3;
    }

    public async Task<GetObjectResponse> GetImage(Guid id)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = BucketName,
            Key = $"images/{id}"
        };
        
        return await _s3.GetObjectAsync(getObjectRequest);
    }

    public async Task<PutObjectResponse> UploadImage(Guid id, IFormFile file)
    {
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = $"images/{id}",
            ContentType = file.ContentType,
            InputStream = file.OpenReadStream(),
            Metadata =
            {
                ["x-amz-meta-originalname"] = file.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(file.FileName)
            }
        };

        return await _s3.PutObjectAsync(putObjectRequest);
    }

    public async Task<DeleteObjectResponse> DeleteImage(Guid id)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = BucketName,
            Key = $"images/{id}"
        };
        
        return await _s3.DeleteObjectAsync(deleteObjectRequest);
    }
}