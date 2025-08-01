using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Paises;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PaisesController(IPaisService paisService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetPaisResponse>>> GetPaiss()
    {
        return await ExecuteServiceAsync(async () => await paisService.GetPaises());
    }

    [HttpGet]
    public async Task<ActionResult<GetPaisResponse?>> GetPais([FromQuery] GetPaisRequest request)
    {
        return await ExecuteServiceAsync(async () => await paisService.GetPais(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreatePaisResponse>> CreatePais([FromBody] CreatePaisRequest request)
    {
        return await ExecuteServiceAsync(async () => await paisService.CreatePais(request), HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdatePaisResponse>> UpdatePais([FromBody] UpdatePaisRequest request)
    {
        return await ExecuteServiceAsync(async () => await paisService.UpdatePais(request));
    }

    [HttpDelete("{paisId:int}/delete")]
    public async Task<ActionResult> DeletePais([FromRoute] int paisId)
    {
        return await ExecuteServiceAsync(async () => await paisService.EliminarReactivarPais(paisId, false));
    }

    [HttpPatch("{paisId:int}/reactive")]
    public async Task<ActionResult> ActivePais([FromRoute] int paisId)
    {
        return await ExecuteServiceAsync(async () => await paisService.EliminarReactivarPais(paisId, true));
    }
}