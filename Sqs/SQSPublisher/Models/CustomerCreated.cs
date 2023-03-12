namespace SQSPublisher.Models;

public record CustomerCreated(Guid Id, string FullName, string Email, string GitHubUsername, DateTime DateOfBirth);