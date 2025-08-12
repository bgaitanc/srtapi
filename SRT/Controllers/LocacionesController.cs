using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Locaciones;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LocacionesController(ILocacionesService locacionesService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetLocacionResponse>>> GetLocacion(
        [FromQuery] int? departamentoId = null)
    {
        return await ExecuteServiceAsync(async () => await locacionesService.GetLocaciones(departamentoId));
    }

    [HttpGet]
    public async Task<ActionResult<GetLocacionResponse?>> GetLocacion([FromQuery] GetLocacionRequest request)
    {
        return await ExecuteServiceAsync(async () => await locacionesService.GetLocacion(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateLocacionResponse>> CreateLocacion([FromBody] CreateLocacionRequest request)
    {
        return await ExecuteServiceAsync(async () => await locacionesService.CreateLocacion(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateLocacionResponse>> UpdateLocacion([FromBody] UpdateLocacionRequest request)
    {
        return await ExecuteServiceAsync(async () => await locacionesService.UpdateLocacion(request));
    }

    [HttpDelete("{locacionId:int}/delete")]
    public async Task<ActionResult<SrtGenericResponse>> DeleteLocacion([FromRoute] int locacionId)
    {
        return await ExecuteServiceAsync(async () =>
            await locacionesService.EliminarReactivarLocacion(locacionId, false));
    }

    [HttpPatch("{locacionId:int}/reactive")]
    public async Task<ActionResult<SrtGenericResponse>> ActiveLocacion([FromRoute] int locacionId)
    {
        return await ExecuteServiceAsync(async () =>
            await locacionesService.EliminarReactivarLocacion(locacionId, true));
    }
}