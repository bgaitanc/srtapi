using Microsoft.AspNetCore.Mvc;

namespace SRT.Controllers.Base;

public class SrtControllerBase : ControllerBase
{
    protected async Task<ActionResult<T>> ExecuteServiceAsync<T>(Func<Task<T>> action)
    {
        try
        {
            var data = await action.Invoke();
            return Ok(data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    protected async Task<ActionResult<T>> ExecuteServiceAsync<T>(Func<Task<T>> action, bool returnUnauthorizedOnNull)
    {
        try
        {
            var data = await action.Invoke();
            if (data is null && returnUnauthorizedOnNull)
            {
                return Unauthorized("Credenciales inválidas");
            }

            return Ok(data);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}