using DynamoDb.Api.Application.UseCases.CreateCustomer;
using DynamoDb.Api.Application.UseCases.GetAllCustomers;
using DynamoDb.Api.Application.UseCases.GetCustomer;
using DynamoDb.Api.Infrastructure.Persistence.Repositories;

namespace DynamoDb.Api.Application.Mapping;

public static class CustomerDtoMapper
{
    public static CreateCustomerResponse MapToCreateCustomerResponse(this CustomerDto dto) => new
    (
        Id: dto.Id,
        FullName: dto.FullName,
        GitHubUsername: dto.GitHubUsername,
        Email: dto.Email, 
        DateOfBirth: dto.DateOfBirth,
        UpdatedAt: dto.UpdatedAt
    );
    
    public static GetCustomerResponse MapToGetCustomerResponse(this CustomerDto dto) => new
    (
        Id: dto.Id,
        FullName: dto.FullName,
        GitHubUsername: dto.GitHubUsername,
        Email: dto.Email, 
        DateOfBirth: dto.DateOfBirth,
        UpdatedAt: dto.UpdatedAt
    );
    
    public static GetAllCustomersResponseItem MapToGetAllCustomerResponseItem(this CustomerDto dto) => new
    (
        Id: dto.Id,
        FullName: dto.FullName,
        GitHubUsername: dto.GitHubUsername,
        Email: dto.Email, 
        DateOfBirth: dto.DateOfBirth,
        UpdatedAt: dto.UpdatedAt
    );
}