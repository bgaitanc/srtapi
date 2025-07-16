using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : SrtControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest request)
    {
        return await ExecuteServiceAsync(async () => await userService.Register(request));
    }
}