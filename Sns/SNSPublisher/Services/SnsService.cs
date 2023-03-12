using Amazon.SimpleNotificationService;
using SNSPublisher.Shared.Configuration.SNS;

namespace SNSPublisher.Services;

public class SnsService : ISnsService
{
    private readonly IAmazonSimpleNotificationService _sns;

    public SnsService(IAmazonSimpleNotificationService sns) => _sns = sns;

    public async Task PublishMessageAsync<T>(T message, string topicName)
    {
        var topic = await _sns.FindTopicAsync(topicName); 
        var sendMessageRequest = PublishRequestBuilder.Build(topic.TopicArn, message);
        await _sns.PublishAsync(sendMessageRequest);
    }
}