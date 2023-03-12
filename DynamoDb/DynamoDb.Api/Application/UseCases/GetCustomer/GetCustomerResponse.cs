namespace DynamoDb.Api.Application.UseCases.GetCustomer;

public record GetCustomerResponse(
    Guid Id,
    string FullName, 
    string Email, 
    string GitHubUsername, 
    DateTime DateOfBirth,
    DateTime UpdatedAt);