using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Departamentos;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DepartamentosController(IDepartamentoService departamentoService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetDepartamentoResponse>>> GetDepartamentos(
        [FromQuery] int? paisId = null)
    {
        return await ExecuteServiceAsync(async () => await departamentoService.GetDepartamentos(paisId));
    }

    [HttpGet]
    public async Task<ActionResult<GetDepartamentoResponse?>> GetDepartamento(
        [FromQuery] GetDepartamentoRequest request)
    {
        return await ExecuteServiceAsync(async () => await departamentoService.GetDepartamento(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateDepartamentoResponse>> CreateDepartamento(
        [FromBody] CreateDepartamentoRequest request)
    {
        return await ExecuteServiceAsync(async () => await departamentoService.CreateDepartamento(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateDepartamentoResponse>> UpdateDepartamento(
        [FromBody] UpdateDepartamentoRequest request)
    {
        return await ExecuteServiceAsync(async () => await departamentoService.UpdateDepartamento(request));
    }

    [HttpDelete("{departamentoId:int}/delete")]
    public async Task<ActionResult<SrtGenericResponse>> DeleteDepartamento([FromRoute] int departamentoId)
    {
        return await ExecuteServiceAsync(async () =>
            await departamentoService.EliminarReactivarDepartamento(departamentoId, false));
    }

    [HttpPatch("{departamentoId:int}/reactive")]
    public async Task<ActionResult<SrtGenericResponse>> ActiveDepartamento([FromRoute] int departamentoId)
    {
        return await ExecuteServiceAsync(async () =>
            await departamentoService.EliminarReactivarDepartamento(departamentoId, true));
    }
}