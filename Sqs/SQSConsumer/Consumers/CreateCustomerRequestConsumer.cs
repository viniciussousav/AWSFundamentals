using Amazon.SQS;
using SQSConsumer.Shared.Configuration.SQS;
using SQSConsumer.Shared.Constants;

#pragma warning disable CS8618

namespace SQSConsumer.Consumers;

public class CreateCustomerRequestConsumer : BackgroundService
{
    private readonly ILogger<CreateCustomerRequestConsumer> _logger;
    private readonly IAmazonSQS _sqs;

    public CreateCustomerRequestConsumer(ILogger<CreateCustomerRequestConsumer> logger, IAmazonSQS sqs)
    {
        _logger = logger;
        _sqs = sqs;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(Queues.CreateCustomerQueue, cancellationToken);

        while (!cancellationToken.IsCancellationRequested)
        {
            var response = await _sqs.ReceiveMessageAsync(ReceiveMessageRequestBuilder.Build(queueUrlResponse.QueueUrl), cancellationToken);

            foreach (var message in response.Messages)
            {
                _logger.LogInformation("Received - MessageId: {MessageId}, Body: {MessageBody}, Timestamp: {TimeOfDay}", 
                    message.MessageId, message.Body, DateTime.Now.TimeOfDay);
                
                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, cancellationToken);
            }
        }
    }
    
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{StopAsync} executed at {CreateCustomerRequestConsumer}", 
            nameof(StopAsync), nameof(CreateCustomerRequestConsumer));
        
        _sqs.Dispose();
        await base.StopAsync(cancellationToken);
    }
}