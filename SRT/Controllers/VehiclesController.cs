using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Vehicles;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VehiclesController(IVehicleService vehicleService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetVehicleResponse>>> GetVehicles()
    {
        return await ExecuteServiceAsync(async () => await vehicleService.GetVehicles());
    }

    [HttpGet]
    public async Task<ActionResult<GetVehicleResponse?>> GetVehicle([FromQuery] GetVehicleRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehicleService.GetVehicle(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateVehicleResponse>> CreateVehicle([FromBody] CreateVehicleRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehicleService.CreateVehicle(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateVehicleResponse>> UpdateVehicle([FromBody] UpdateVehicleRequest request)
    {
        return await ExecuteServiceAsync(async () => await vehicleService.UpdateVehicle(request));
    }
}