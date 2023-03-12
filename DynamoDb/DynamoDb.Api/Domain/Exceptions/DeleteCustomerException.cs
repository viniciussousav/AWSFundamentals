using System.Diagnostics.CodeAnalysis;

namespace DynamoDb.Api.Domain.Exceptions;

[Serializable, ExcludeFromCodeCoverage]
public class DeleteCustomerException : Exception
{
    public DeleteCustomerException()
    {
    }

    public DeleteCustomerException(string message)
        : base(message)
    {
    }

    public DeleteCustomerException(string message, Exception inner)
        : base(message, inner)
    {
    }
}