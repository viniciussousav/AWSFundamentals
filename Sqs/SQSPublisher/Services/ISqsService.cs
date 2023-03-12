namespace SQSPublisher.Services;

public interface ISqsService
{
    Task SendMessageAsync<T>(T message, string queue);
}