namespace SQSConsumer.Models;

public record CreateCustomerRequest(string FullName, string Email, string GitHubUsername, DateTime DateOfBirth);