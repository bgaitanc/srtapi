using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EstadosController(IEstadoService estadoService) : SrtControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetEstadoResponse?>> GetEstado([FromQuery] GetEstadoRequest request)
    {
        return await ExecuteServiceAsync(async () => await estadoService.GetEstado(request));
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetEstadoResponse>>> GetEstados()
    {
        return await ExecuteServiceAsync(async () => await estadoService.GetEstados());
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateEstadoResponse>> CreateEstado([FromBody] CreateEstadoRequest request)
    {
        return await ExecuteServiceAsync(async () => await estadoService.CreateEstado(request), HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateEstadoResponse>> UpdateEstado([FromBody] UpdateEstadoRequest request)
    {
        return await ExecuteServiceAsync(async () => await estadoService.UpdateEstado(request));
    }

    [HttpDelete("{estadoId:int}/delete")]
    public async Task<ActionResult<SrtGenericResponse>> DeleteEstado([FromRoute] int estadoId)
    {
        return await ExecuteServiceAsync(async () => await estadoService.EliminarReactivarEstado(estadoId, false));
    }

    [HttpPatch("{estadoId:int}/reactive")]
    public async Task<ActionResult<SrtGenericResponse>> ActiveEstado([FromRoute] int estadoId)
    {
        return await ExecuteServiceAsync(async () => await estadoService.EliminarReactivarEstado(estadoId, true));
    }
}