using System.Text.Json;
using Amazon.SQS.Model;

namespace SQSPublisher.Shared.Configuration.SQS;

public static class SendMessageRequestBuilder
{
    public static SendMessageRequest Build<T>(string queueUrl, T message)
    {
        return new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = typeof(T).Name
                    }
                }
            }
        };
    }
}