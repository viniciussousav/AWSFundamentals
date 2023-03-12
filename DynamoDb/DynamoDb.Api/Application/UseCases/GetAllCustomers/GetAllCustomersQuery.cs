using MediatR;

namespace DynamoDb.Api.Application.UseCases.GetAllCustomers;

public record GetAllCustomersQuery : IRequest<GetAllCustomersResponse>;