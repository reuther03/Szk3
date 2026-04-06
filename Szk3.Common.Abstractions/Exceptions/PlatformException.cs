using System.Net;

namespace Szk3.Common.Abstractions.Exceptions;

public abstract class PlatformException : Exception
{
    private int _apiHttpErrorCode = (int)HttpStatusCode.BadRequest;

    protected PlatformException(int apiHttpErrorCode, string message)
        : this(apiHttpErrorCode, message, null, null)
    {
    }

    protected PlatformException(int apiHttpErrorCode, string message, string? errorCode)
        : this(apiHttpErrorCode, message, errorCode, null)
    {
    }

    protected PlatformException(int apiHttpErrorCode, string message, Exception? innerException)
        : this(apiHttpErrorCode, message, null, innerException)
    {
    }

    protected PlatformException(int apiHttpErrorCode, string message, string? errorCode, Exception? innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
        _apiHttpErrorCode = apiHttpErrorCode;
    }

    public int ApiHttpErrorCode => _apiHttpErrorCode;

    public string? ErrorCode { get; protected set; }

    public PlatformException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public PlatformException WithData(string name, object value)
    {
        Data[name] = value;
        return this;
    }
}
