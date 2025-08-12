using System.Net;

namespace SRT.Controllers.Base;

public class SrtGenericResponse
{
    public object Data { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
}