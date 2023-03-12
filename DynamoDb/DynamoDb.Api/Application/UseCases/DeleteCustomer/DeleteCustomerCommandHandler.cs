using DynamoDb.Api.Domain.Exceptions;
using DynamoDb.Api.Domain.Repositories;

namespace DynamoDb.Api.Application.UseCases.DeleteCustomer;

public class DeleteCustomerCommandHandler : IDeleteCustomerCommandHandler
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<DeleteCustomerResponse?> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetAsync(command.Id) is null)
            return null;

        var result = await _customerRepository.DeleteAsync(command.Id);

        if (!result)
            throw new DeleteCustomerException($"Error while deleting customer with Id {command.Id}");

        return new DeleteCustomerResponse();
    }
}