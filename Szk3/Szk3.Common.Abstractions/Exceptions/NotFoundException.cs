using System.Net;

namespace Szk3.Common.Abstractions.Exceptions;

public class NotFoundException : PlatformException
{
    public NotFoundException(string message, Exception? innerException = null)
        : base((int)HttpStatusCode.NotFound, message, innerException)
    {
    }
}
