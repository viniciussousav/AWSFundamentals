using MediatR;

namespace DynamoDb.Api.Application.UseCases.UpdateCustomer;

public record UpdateCustomerCommand(
    Guid Id,
    string FullName,
    string Email,
    string GitHubUsername,
    DateTime DateOfBirth) : IRequest<UpdateCustomerResponse>;