using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SRT.Controllers.Base;

public class SrtControllerBase : ControllerBase
{
    protected async Task<ActionResult<T>> ExecuteServiceAsync<T>(Func<Task<T>> action,
        HttpStatusCode status = HttpStatusCode.OK)
    {
        try
        {
            var data = await action.Invoke();
            return data is null ? NotFound() : GenerateActionResult(status, data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    private ActionResult GenerateActionResult<T>(HttpStatusCode status, T? data)
    {
        return status switch
        {
            HttpStatusCode.Created => Created("", data),
            _ => Ok(data)
        };
    }

    protected async Task<ActionResult> ExecuteServiceAsync(Func<Task> action)
    {
        try
        {
            await action.Invoke();

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    protected async Task<ActionResult<T>> ExecuteServiceAsync<T>(Func<Task<T>> action, bool returnUnauthorizedOnNull,
        HttpStatusCode status = HttpStatusCode.OK)
    {
        try
        {
            var data = await action.Invoke();
            if (data is null && returnUnauthorizedOnNull)
            {
                return Unauthorized("Credenciales inválidas");
            }

            return GenerateActionResult(status, data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}