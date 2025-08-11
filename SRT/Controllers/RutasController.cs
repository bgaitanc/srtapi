using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Rutas;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RutasController(IRutasService rutasService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetRutaWithNamesResponse>>> GetRuta()
    {
        return await ExecuteServiceAsync(async () => await rutasService.GetRutasWithNames());
    }

    [HttpGet]
    public async Task<ActionResult<GetRutaResponse?>> GetRuta([FromQuery] GetRutaRequest request)
    {
        return await ExecuteServiceAsync(async () => await rutasService.GetRuta(request));
    }

    //TODO hay que revisar de que manera se enviará el campo TiempoEstimado, aplica también para el update
    [HttpPost("create")]
    public async Task<ActionResult<CreateRutaResponse>> CreateRuta([FromBody] CreateRutaRequest request)
    {
        return await ExecuteServiceAsync(async () => await rutasService.CreateRuta(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateRutaResponse>> UpdateRuta([FromBody] UpdateRutaRequest request)
    {
        return await ExecuteServiceAsync(async () => await rutasService.UpdateRuta(request));
    }

    [HttpDelete("{rutaId:int}/delete")]
    public async Task<ActionResult> DeleteRuta([FromRoute] int rutaId)
    {
        return await ExecuteServiceAsync(async () => await rutasService.EliminarReactivarRuta(rutaId, false));
    }

    [HttpPatch("{rutaId:int}/reactive")]
    public async Task<ActionResult> ActiveRuta([FromRoute] int rutaId)
    {
        return await ExecuteServiceAsync(async () => await rutasService.EliminarReactivarRuta(rutaId, true));
    }
}