using DynamoDb.Api.Application.Mapping;
using DynamoDb.Api.Domain.Exceptions;
using DynamoDb.Api.Domain.Repositories;

namespace DynamoDb.Api.Application.UseCases.CreateCustomer;

public class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
{
    private readonly ILogger<CreateCustomerCommandHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    
    public CreateCustomerCommandHandler(ILogger<CreateCustomerCommandHandler> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }
    
    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customerDto = command.MapToDto();
        var result = await _customerRepository.CreateAsync(customerDto);

        if (!result)
            throw new CreateCustomerException("Error occured while creating customer");
        
        return customerDto.MapToCreateCustomerResponse();
    }
}