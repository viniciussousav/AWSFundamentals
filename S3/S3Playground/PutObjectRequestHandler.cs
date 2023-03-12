using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

namespace S3Playground;

public class PutObjectRequestHandler : IDisposable
{
    private readonly AmazonS3Client _s3Client;
    
    public PutObjectRequestHandler()
    {
        _s3Client = new AmazonS3Client();
    }
    
    public async Task PutImage()
    {
        await using var inputStream = new FileStream("./Profile.png", FileMode.Open, FileAccess.Read);

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = "vsv-aws-fundamentals",
            Key = "images/Profile.png",
            ContentType = "image/png",
            InputStream = inputStream
        };

        await _s3Client.PutObjectAsync(putObjectRequest);
    }
    
    public async Task PutCsv()
    {
        await using var inputStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = "vsv-aws-fundamentals",
            Key = "files/movies.csv",
            ContentType = "text/csv",
            InputStream = inputStream
        };

        await _s3Client.PutObjectAsync(putObjectRequest);
    }

    public async Task<string> GetCsvAsText()
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = "vsv-aws-fundamentals",
            Key = "files/movies.csv"
        };

        var response = await _s3Client.GetObjectAsync(getObjectRequest);
        
        using var memoryStream = new MemoryStream();
        await response.ResponseStream.CopyToAsync(memoryStream);

        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
    public void Dispose()
    {
        _s3Client.Dispose();
    }
}