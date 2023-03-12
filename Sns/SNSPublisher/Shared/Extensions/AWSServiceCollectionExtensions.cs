using Amazon.SimpleNotificationService;
using SNSPublisher.Services;

namespace SNSPublisher.Shared.Extensions;

public static class AwsServiceCollectionExtensions
{
    public static void AddAwsServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>();  
        serviceCollection.AddScoped<ISnsService, SnsService>();
    }
}