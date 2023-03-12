using Amazon.DynamoDBv2;
using Amazon.S3;
using AmazonS3Example.API.Domain.Repositories;
using AmazonS3Example.API.Infrastructure.Persistence.Repositories;
using AmazonS3Example.API.Infrastructure.Services.S3;

namespace AmazonS3Example.API.Infrastructure;

public static class ServiceCollectionExtensions
{
    private static void AddAwsInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
        serviceCollection.AddScoped<IAmazonS3, AmazonS3Client>();
    }
    
    private static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IImageRepository, ImageRepository>();
        serviceCollection.AddScoped<IImageService, ImageService>();
    }

    public static void AddInfrastructureDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAwsInfrastructure();
        serviceCollection.AddRepositories();
    }
}