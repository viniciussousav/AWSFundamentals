using MediatR;

namespace DynamoDb.Api.Application.UseCases.GetAllCustomers;

public interface IGetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, GetAllCustomersResponse>
{
    
}