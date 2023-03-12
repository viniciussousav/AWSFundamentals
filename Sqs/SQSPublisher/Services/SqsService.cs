using Amazon.SQS;
using SQSPublisher.Shared.Configuration.SQS;

namespace SQSPublisher.Services;

public class SqsService : ISqsService
{
    private readonly IAmazonSQS _sqs;

    public SqsService(IAmazonSQS sqs) => _sqs = sqs;

    public async Task SendMessageAsync<T>(T message, string queue)
    {
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(queue);
        var sendMessageRequest = SendMessageRequestBuilder.Build(queueUrlResponse.QueueUrl, message);
        await _sqs.SendMessageAsync(sendMessageRequest);
    }
    
}