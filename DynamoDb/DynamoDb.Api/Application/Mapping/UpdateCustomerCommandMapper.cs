using DynamoDb.Api.Application.UseCases.UpdateCustomer;
using DynamoDb.Api.Infrastructure.Persistence.Repositories;

namespace DynamoDb.Api.Application.Mapping;

public static class UpdateCustomerCommandMapper
{
    public static CustomerDto MapToCustomerDto(this UpdateCustomerCommand command) => new()
    {
        Id = command.Id,
        FullName = command.FullName,
        Email = command.Email,
        GitHubUsername = command.GitHubUsername,
        DateOfBirth = command.DateOfBirth
    };
}