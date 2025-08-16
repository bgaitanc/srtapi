using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ReservasController(IReservasService reservasService, IDetalleReservasService detalleReservasService) : SrtControllerBase
{
    [HttpGet("detalle")]
    public async Task<ActionResult<GetDetalleReservasResponse>> GetDetalleReservasPorViaje([FromQuery] int viajeId)
    {
        return await ExecuteServiceAsync(async () => await detalleReservasService.GetDetalleReservasByViajeId(viajeId));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateReservaResponse>> CreateReserva([FromBody] CreateReservaRequest request)
    {
        return await ExecuteServiceAsync(async () => await reservasService.CreateReserva(request), HttpStatusCode.Created);
    }
}