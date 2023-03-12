using System.Text.Json;
using Amazon.SimpleNotificationService.Model;

namespace SNSPublisher.Shared.Configuration.SNS;

public static class PublishRequestBuilder
{
    public static PublishRequest Build<T>(string queueUrl, T message)
    {
        return new PublishRequest
        {
            TopicArn = queueUrl,
            Message = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = typeof(T).Name
                    }
                },
                {
                    "AwsService", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = "SNS"
                    }
                }
            }
        };
    }
}