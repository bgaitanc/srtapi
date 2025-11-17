using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.States;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StatesController(IStateService stateService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetStateResponse>>> GetStates([FromQuery] Guid? countryId = null)
    {
        return await ExecuteServiceAsync(async () => await stateService.GetStates(countryId), returnSuccessOnEmpty: true);
    }

    [HttpGet]
    public async Task<ActionResult<GetStateResponse?>> GetState([FromQuery] GetStateRequest request)
    {
        return await ExecuteServiceAsync(async () => await stateService.GetState(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateStateResponse>> CreateState([FromBody] CreateStateRequest request)
    {
        return await ExecuteServiceAsync(async () => await stateService.CreateState(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateStateResponse>> UpdateState(
        [FromBody] UpdateStateRequest request)
    {
        return await ExecuteServiceAsync(async () => await stateService.UpdateState(request));
    }
}