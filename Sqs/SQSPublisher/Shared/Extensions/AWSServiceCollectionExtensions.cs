using Amazon.SQS;
using SQSPublisher.Services;

namespace SQSPublisher.Shared.Extensions;

public static class AwsServiceCollectionExtensions
{
    public static void AddAwsServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAmazonSQS, AmazonSQSClient>();  
        serviceCollection.AddScoped<ISqsService, SqsService>();
    }
}