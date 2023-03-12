namespace DynamoDb.Api.Application.UseCases.GetAllCustomers;

public record GetAllCustomersResponse(IEnumerable<GetAllCustomersResponseItem> customers);