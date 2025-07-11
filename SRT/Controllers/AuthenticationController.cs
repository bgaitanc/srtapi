using Microsoft.AspNetCore.Mvc;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Services.Interface;

namespace SRT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate([FromBody] AuthenticationRequest request)
    {
        var data = await _authenticationService.GenerateToken(request);

        if (data is null)
        {
            Unauthorized("Credenciales inválidas");
        }

        return Ok(data);
    }
}