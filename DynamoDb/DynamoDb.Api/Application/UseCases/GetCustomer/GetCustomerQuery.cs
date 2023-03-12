using MediatR;

namespace DynamoDb.Api.Application.UseCases.GetCustomer;

public record GetCustomerQuery(Guid Id) : IRequest<GetCustomerResponse>;