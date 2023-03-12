using DynamoDb.Api.Application.Mapping;
using DynamoDb.Api.Domain.Exceptions;
using DynamoDb.Api.Domain.Repositories;

namespace DynamoDb.Api.Application.UseCases.UpdateCustomer;

public class UpdateCustomerCommandHandler : IUpdateCustomerCommandHandler
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<UpdateCustomerResponse?> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customerDto = command.MapToCustomerDto();

        if (await _customerRepository.GetAsync(command.Id) is null)
            return null;
        
        var response = await _customerRepository.UpdateAsync(customerDto);

        if (!response)
            throw new UpdateCustomerException($"Error while updating customer with id {command.Id}");

        return new UpdateCustomerResponse();
    }
}