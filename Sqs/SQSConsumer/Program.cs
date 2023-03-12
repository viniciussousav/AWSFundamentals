using Amazon.SQS;
using SQSConsumer.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IAmazonSQS, AmazonSQSClient>();
        services.AddHostedService<CreateCustomerRequestConsumer>();
    })
    .Build();

await host.RunAsync();