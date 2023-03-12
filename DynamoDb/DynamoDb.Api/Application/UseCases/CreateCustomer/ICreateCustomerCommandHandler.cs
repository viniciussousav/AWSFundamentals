using MediatR;

namespace DynamoDb.Api.Application.UseCases.CreateCustomer;

public interface ICreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
}