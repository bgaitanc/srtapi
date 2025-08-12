using System.Net;

namespace SRT.Domain.Utils.Exceptions;

public class SrtException : Exception
{
    public SrtException()
    {
    }

    public SrtException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; set; }
}