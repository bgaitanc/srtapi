using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Helpers;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class AuthenticationService(IUserService userService, IOptions<AppSettings> appSettings)
    : IAuthenticationService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task<AuthenticationResponse?> GenerateToken(AuthenticationRequest request)
    {
        var user = await userService.GetUser(request.User);
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Contrasena))
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
                new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new AuthenticationResponse(tokenString);
    }
}