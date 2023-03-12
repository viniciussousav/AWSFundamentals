namespace DynamoDb.Api.Application.UseCases.GetAllCustomers;

public record GetAllCustomersResponseItem(
    Guid Id,
    string FullName, 
    string Email, 
    string GitHubUsername, 
    DateTime DateOfBirth,
    DateTime UpdatedAt);