using MediatR;

namespace DynamoDb.Api.Application.UseCases.GetCustomer;

public interface IGetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse?>
{
}

