using System.Collections;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Controllers.Base;

public class SrtControllerBase : ControllerBase
{
    protected async Task<ActionResult<SrtGenericResponse>> ExecuteServiceAsync(Func<Task> action)
    {
        try
        {
            await action.Invoke();

            return NoContent();
        }
        catch (Exception e)
        {
            return GenerateActionResult(new SrtGenericResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Success = false,
                Message = e.Message
            });
        }
    }

    protected async Task<ActionResult<T>> ExecuteServiceAsync<T>(Func<Task<T>> action, HttpStatusCode status = HttpStatusCode.OK, bool returnSuccessOnEmpty = false)
    {
        try
        {
            var data = await action.Invoke();
            if (status == HttpStatusCode.NoContent)
            {
                return NoContent();
            }

            if (!returnSuccessOnEmpty && (data == null || data is IEnumerable enumerable && !enumerable.Cast<object>().Any()))
            {
                return GenerateActionResult(new SrtGenericResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false,
                    Message = "No Data Found"
                });
            }
 
            return GenerateActionResult(new SrtGenericResponse
            {
                StatusCode = status,
                Success = true,
                Data = data!
            });
        }
        catch (SrtException srtEx)
        {
            return GenerateActionResult(new SrtGenericResponse
            {
                StatusCode = srtEx.StatusCode,
                Success = false,
                Message = srtEx.Message
            });
        }
        catch (Exception e)
        {
            return GenerateActionResult(new SrtGenericResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Success = false,
                Message = e.Message
            });
        }
    }

    private ObjectResult GenerateActionResult(SrtGenericResponse response)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.Created => Created("", response),
            HttpStatusCode.NotFound => NotFound(response),
            HttpStatusCode.Unauthorized => Unauthorized(response),
            _ => BadRequest(response)
        };
    }
}