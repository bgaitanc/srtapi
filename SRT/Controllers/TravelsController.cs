using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Travels;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TravelsController(ITravelService travelService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetTravelResponse>>> GetTravels()
    {
        return await ExecuteServiceAsync(async () => await travelService.GetTravels());
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateTravelResponse>> CreateTravel([FromBody] CreateTravelRequest request)
    {
        return await ExecuteServiceAsync(async () => await travelService.CreateTravel(request));
    }
}