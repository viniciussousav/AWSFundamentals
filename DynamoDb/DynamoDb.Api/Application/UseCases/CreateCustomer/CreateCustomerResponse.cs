namespace DynamoDb.Api.Application.UseCases.CreateCustomer;

public record CreateCustomerResponse(
    Guid Id,
    string FullName, 
    string Email, 
    string GitHubUsername, 
    DateTime DateOfBirth,
    DateTime UpdatedAt);