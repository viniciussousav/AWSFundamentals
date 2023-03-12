using Amazon.SQS.Model;

namespace SQSConsumer.Shared.Configuration.SQS;

public static class ReceiveMessageRequestBuilder
{
    public static ReceiveMessageRequest Build(string queueUrl)
    {
        return new ReceiveMessageRequest
        {
            QueueUrl = queueUrl,
            AttributeNames = new List<string>{ "All" },
            MessageAttributeNames = new List<string>{ "All" },
        };
    }
}