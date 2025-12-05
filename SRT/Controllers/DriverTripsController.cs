using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Services.Interface;
using System.Security.Claims;
using SRT.Domain.Models.Dtos.DriverTrips;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DriverTripsController(IDriverTripService driverTripService) : SrtControllerBase
{
    [HttpGet("assigned")]
    public async Task<ActionResult<IEnumerable<AssignedTripResponse>>> GetAssignedTrips(
        [FromQuery] string? status = null,
        [FromQuery] DateTime? date = null)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var driverId))
            return Unauthorized();

        return await ExecuteServiceAsync(async () =>
            await driverTripService.GetAssignedTrips(driverId, status, date));
    }

    [HttpPost("{travelId}/complete")]
    public async Task<IActionResult> CompleteTrip([FromRoute] Guid travelId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var driverId))
            return Unauthorized();

        await ExecuteServiceAsync(async () => await driverTripService.CompleteTrip(travelId, driverId));
        return Ok(new {
            data = (object?)null,
            message = "Viaje completado exitosamente",
            statusCode = 200,
            success = true
        });
    }
}
