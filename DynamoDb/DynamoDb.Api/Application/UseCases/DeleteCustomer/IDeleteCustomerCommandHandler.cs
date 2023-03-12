using MediatR;

namespace DynamoDb.Api.Application.UseCases.DeleteCustomer;

public interface IDeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse?>
{
    
}