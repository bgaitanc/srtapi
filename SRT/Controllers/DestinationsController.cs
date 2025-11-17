using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Destinations;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DestinationsController(IDestinationService destinationsService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetDestinationResponse>>> GetDestination(
        [FromQuery] Guid? stateId = null)
    {
        return await ExecuteServiceAsync(async () => await destinationsService.GetDestinations(stateId));
    }

    [HttpGet]
    public async Task<ActionResult<GetDestinationResponse?>> GetDestination([FromQuery] GetDestinationRequest request)
    {
        return await ExecuteServiceAsync(async () => await destinationsService.GetDestination(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateDestinationResponse>> CreateDestination(
        [FromBody] CreateDestinationRequest request)
    {
        return await ExecuteServiceAsync(async () => await destinationsService.CreateDestination(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateDestinationResponse>> UpdateDestination(
        [FromBody] UpdateDestinationRequest request)
    {
        return await ExecuteServiceAsync(async () => await destinationsService.UpdateDestination(request));
    }
}