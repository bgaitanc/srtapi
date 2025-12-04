using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Roles;
using SRT.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace SRT.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RolesController(IRoleService rolService) : SrtControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        => await ExecuteServiceAsync(() => rolService.GetAllRolesAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto?>> GetById(Guid id)
        => await ExecuteServiceAsync(() => rolService.GetRoleByIdAsync(id));

    [HttpPost]
    public async Task<ActionResult<RoleDto>> Create([FromBody] CreateRoleRequest request)
        => await ExecuteServiceAsync(() => rolService.CreateRoleAsync(request), HttpStatusCode.Created);

    [HttpPut]
    public async Task<ActionResult<RoleDto>> Update([FromBody] UpdateRoleRequest request)
        => await ExecuteServiceAsync(() => rolService.UpdateRoleAsync(request));

    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromBody] DeleteRoleRequest request)
        => await ExecuteServiceAsync(() => rolService.DeleteRoleAsync(request), HttpStatusCode.NoContent);
}
