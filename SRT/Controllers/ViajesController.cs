using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ViajesController(IViajesService viajesService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetViajesResponse>>> GetViajes()
    {
        return await ExecuteServiceAsync(async () => await viajesService.GetViajes());
    }
}