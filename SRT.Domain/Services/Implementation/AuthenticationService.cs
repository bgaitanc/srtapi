using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Helpers;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly AppSettings _appSettings;

    public AuthenticationService(IUserService userService, IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _appSettings = appSettings.Value;
    }

    public async Task<AuthenticationResponse?> GenerateToken(AuthenticationRequest request)
    {
        var user = await _userService.Authenticate(request);
        if (user is null)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var secret = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Usuario),
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioID.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new AuthenticationResponse(user, tokenString);
    }
}