using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Entities;
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
}