using MediatR;

namespace DynamoDb.Api.Application.UseCases.DeleteCustomer;

public record DeleteCustomerCommand(
    Guid Id) : IRequest<DeleteCustomerResponse>;
