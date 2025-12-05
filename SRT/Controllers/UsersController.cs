using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : SrtControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest request)
    {
        return await ExecuteServiceAsync(async () => await userService.Register(request), HttpStatusCode.Created);
    }

    [HttpGet("info")]
    public async Task<ActionResult<UserInfoResponse>> GetUserInfo()
    {
        var user = User.FindFirst(ClaimTypes.Name)?.Value;

        return (await ExecuteServiceAsync(async () => await userService.GetUserInfo(user!)))!;
    }

    [HttpPost("assign-role")]
    public async Task<ActionResult<bool>> AssignRole([FromBody] AssignUserRoleRequest request)
    {
        return await ExecuteServiceAsync(async () => {
            await userService.AssignRoleToUser(request.UserId, request.RoleId);
            return true;
        });
    }

    [HttpPost("remove-role")]
    public async Task<ActionResult<bool>> RemoveRole([FromBody] RemoveUserRoleRequest request)
    {
        return await ExecuteServiceAsync(async () => {
            await userService.RemoveRoleFromUser(request.UserId, request.RoleId);
            return true;
        });
    }

    [HttpGet("{userId}/roles")]
    public async Task<ActionResult<IEnumerable<string>>> GetUserRoles(Guid userId)
    {
        return await ExecuteServiceAsync(async () => await userService.GetUserRoles(userId));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfoResponse>>> GetAll()
    {
        return await ExecuteServiceAsync(async () => await userService.GetAllUsers());
    }

    [HttpPut("profile")]
    public async Task<ActionResult<UserInfoResponse>> UpdateProfile([FromBody] UpdateUserProfileRequest request)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        return await ExecuteServiceAsync(async () => await userService.UpdateUserProfile(userId, request));
    }
}