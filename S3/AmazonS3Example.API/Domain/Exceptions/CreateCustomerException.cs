using System.Diagnostics.CodeAnalysis;

namespace AmazonS3Example.API.Domain.Exceptions;

[Serializable, ExcludeFromCodeCoverage]
public class CreateCustomerException : Exception
{
    public CreateCustomerException() { }

    public CreateCustomerException(string message)
        : base(message) { }

    public CreateCustomerException(string message, Exception inner)
        : base(message, inner) { }
}