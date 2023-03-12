using Amazon.DynamoDBv2;
using DynamoDb.Api.Domain.Repositories;
using DynamoDb.Api.Infrastructure.Persistence.Repositories;

namespace DynamoDb.Api.Infrastructure;

public static class ServiceCollectionExtensions
{
    private static void AddAwsInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
    }
    
    private static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static void AddInfrastructureDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAwsInfrastructure();
        serviceCollection.AddRepositories();
    }
}