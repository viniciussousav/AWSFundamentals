using DynamoDb.Api.Application.Mapping;
using DynamoDb.Api.Domain.Repositories;

namespace DynamoDb.Api.Application.UseCases.GetCustomer;

public class GetCustomerQueryHandler : IGetCustomerQueryHandler
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetCustomerResponse?> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(query.Id);
        return customer?.MapToGetCustomerResponse();
    }
}