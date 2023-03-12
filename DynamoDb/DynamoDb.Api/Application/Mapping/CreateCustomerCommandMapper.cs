using DynamoDb.Api.Application.UseCases.CreateCustomer;
using DynamoDb.Api.Infrastructure.Persistence.Repositories;

namespace DynamoDb.Api.Application.Mapping;

public static class CreateCustomerCommandMapper
{
    public static CustomerDto MapToDto(this CreateCustomerCommand command) => new ()
    {
        Id = Guid.NewGuid(),
        FullName = command.FullName,
        Email = command.Email,
        GitHubUsername = command.GitHubUsername,
        DateOfBirth = command.DateOfBirth
    };
}