using Microsoft.AspNetCore.Mvc;
using SRT.Controllers.Base;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService authenticationService) : SrtControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse?>> Authenticate([FromBody] AuthenticationRequest request)
    {
        return await ExecuteServiceAsync(async () => await authenticationService.GenerateToken(request), true);
    }
}