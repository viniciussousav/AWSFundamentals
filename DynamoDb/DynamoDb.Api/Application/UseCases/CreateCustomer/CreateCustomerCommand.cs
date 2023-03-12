using MediatR;

namespace DynamoDb.Api.Application.UseCases.CreateCustomer;

public record CreateCustomerCommand(
    string FullName,
    string Email,
    string GitHubUsername,
    DateTime DateOfBirth) : IRequest<CreateCustomerResponse>;
    
    
