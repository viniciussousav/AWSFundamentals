namespace SNSPublisher.Services;

public interface ISnsService
{
    Task PublishMessageAsync<T>(T message, string topicName);
}