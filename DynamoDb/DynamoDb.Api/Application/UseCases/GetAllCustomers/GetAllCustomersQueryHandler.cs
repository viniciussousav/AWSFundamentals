using DynamoDb.Api.Application.Mapping;
using DynamoDb.Api.Domain.Repositories;
using MediatR;

namespace DynamoDb.Api.Application.UseCases.GetAllCustomers;

public class GetAllCustomersQueryHandler : IGetAllCustomersQueryHandler
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetAllCustomersResponse> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync();

        var customersResponse = customers
            .Select(customer => customer.MapToGetAllCustomerResponseItem());

        return new GetAllCustomersResponse(customers: customersResponse);
    }
}