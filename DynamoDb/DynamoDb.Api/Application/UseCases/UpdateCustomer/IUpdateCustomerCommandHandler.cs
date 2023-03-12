using MediatR;

namespace DynamoDb.Api.Application.UseCases.UpdateCustomer;

public interface IUpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse?>
{
    
}