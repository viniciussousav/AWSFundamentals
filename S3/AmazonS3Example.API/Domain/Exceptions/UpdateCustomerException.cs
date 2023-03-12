using System.Diagnostics.CodeAnalysis;

namespace AmazonS3Example.API.Domain.Exceptions;

[Serializable, ExcludeFromCodeCoverage]
public class UpdateCustomerException : Exception
{
    public UpdateCustomerException()
    {
    }

    public UpdateCustomerException(string message)
        : base(message)
    {
    }

    public UpdateCustomerException(string message, Exception inner)
        : base(message, inner)
    {
    }
}