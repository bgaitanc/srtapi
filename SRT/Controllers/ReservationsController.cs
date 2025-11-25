using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Reservations;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ReservationsController(
    IReservationService reservationService,
    IReservationDetailService reservationDetailService) : SrtControllerBase
{
    [HttpGet("detail")]
    public async Task<ActionResult<GetReservationDetailResponse>> GetReservationDetailByTravel(
        [FromQuery] Guid travelId)
    {
        return await ExecuteServiceAsync(async () =>
            await reservationDetailService.GetReservationDetailByTravelId(travelId));
    }

    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<GetReservationInfoResponse>>> GetReservationDetailByUser(
        [FromQuery] Guid userId)
    {
        return await ExecuteServiceAsync(async () => await reservationService.GetReservationDetailsByUserId(userId));
    }

    [HttpPost("create")]
    public async Task<ActionResult<GetReservationInfoResponse>> CreateReservation(
        [FromBody] CreateReservationRequest request)
    {
        return await ExecuteServiceAsync(async () => await reservationService.CreateReservation(request),
            HttpStatusCode.Created);
    }
}