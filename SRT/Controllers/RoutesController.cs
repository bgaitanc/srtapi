using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Routes;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RoutesController(IRouteService routeService) : SrtControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetRouteWithNamesResponse>>> GetRoutes()
    {
        return await ExecuteServiceAsync(async () => await routeService.GetRoutesWithNames());
    }

    [HttpGet]
    public async Task<ActionResult<GetRouteResponse?>> GetRoute([FromQuery] GetRouteRequest request)
    {
        return await ExecuteServiceAsync(async () => await routeService.GetRoute(request));
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateRouteResponse>> CreateRoute([FromBody] CreateRouteRequest request)
    {
        return await ExecuteServiceAsync(async () => await routeService.CreateRoute(request),
            HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UpdateRouteResponse>> UpdateRoute([FromBody] UpdateRouteRequest request)
    {
        return await ExecuteServiceAsync(async () => await routeService.UpdateRoute(request));
    }
}