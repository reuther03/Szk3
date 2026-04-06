using System.Net;

namespace Szk3.Common.Abstractions.Exceptions
{
    public class PlatformBusinessException : PlatformException
    {
        public PlatformBusinessException(string message, string errorCode, Exception? innerException = null)
            : base((int)HttpStatusCode.BadRequest, message, errorCode, innerException)
        {
        }
    }
}
