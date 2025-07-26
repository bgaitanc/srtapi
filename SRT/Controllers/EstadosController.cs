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
    public async Task<ActionResult<GetEstadoResponse>> GetEstadoByName([FromQuery] GetEstadoRequest request)
    {
        return await ExecuteServiceAsync(async () => await estadoService.GetEstado(request));
    }
}