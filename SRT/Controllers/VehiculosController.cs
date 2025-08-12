using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VehiculosController(IVehiculosService vehiculosService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetVehiculoResponse>>> GetVehiculo()
    {
        return await ExecuteServiceAsync(async () => await vehiculosService.GetVehiculos());
    }

    [HttpGet]
    public async Task<ActionResult<GetVehiculoResponse?>> GetVehiculo([FromQuery] GetVehiculoRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehiculosService.GetVehiculo(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateVehiculoResponse>> CreateVehiculo([FromBody] CreateVehiculoRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehiculosService.CreateVehiculo(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateVehiculoResponse>> UpdateVehiculo([FromBody] UpdateVehiculoRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehiculosService.UpdateVehiculo(request));
    }

    [HttpDelete("{vehiculoId:int}/delete")]
    public async Task<ActionResult<SrtGenericResponse>> DeleteVehiculo([FromRoute] int vehiculoId)
    {
        return await ExecuteServiceAsync(async () =>
            await vehiculosService.EliminarReactivarVehiculo(vehiculoId, false));
    }

    [HttpPatch("{vehiculoId:int}/reactive")]
    public async Task<ActionResult<SrtGenericResponse>> ActiveVehiculo([FromRoute] int vehiculoId)
    {
        return await ExecuteServiceAsync(async () =>
            await vehiculosService.EliminarReactivarVehiculo(vehiculoId, true));
    }
}