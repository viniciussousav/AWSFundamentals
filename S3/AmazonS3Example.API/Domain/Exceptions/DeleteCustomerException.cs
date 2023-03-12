using System.Diagnostics.CodeAnalysis;

namespace AmazonS3Example.API.Domain.Exceptions;

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