using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Helpers;
using SRT.Domain.Services.Interface;
using SRT.Domain.Utils.Constants;
using SRT.Domain.Utils.Exceptions;

namespace SRT.Domain.Services.Implementation;

public class AuthenticationService(
    IUserService userService,
    IUserRolService userRolService,
    IOptions<AppSettings> appSettings)
    : IAuthenticationService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task<AuthenticationResponse> GenerateToken(AuthenticationRequest request)
    {
        var user = await userService.GetUser(request.Username);
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new SrtException(HttpStatusCode.Unauthorized, "Credenciales invalidas");
        }

        var roles = await userRolService.GetUserRoles(user.Id);
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(CustomClaimTypes.Roles, JsonSerializer.Serialize(roles?.Roles ?? new List<string>()))
        };

        var accessToken = GenerateAccessToken(claims);
        var refreshToken = GenerateRefreshTokenString();

        await UpdateUserRefreshToken(user, refreshToken);

        return new AuthenticationResponse(accessToken, refreshToken);
    }

    public async Task<AuthenticationResponse> RefreshToken(RefreshTokenRequest request)
    {
        var principal = await GetPrincipalFromExpiredToken(request.AccessToken);
        if (principal == null)
            throw new SrtException(HttpStatusCode.BadRequest, "Token invalido");

        var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            throw new SrtException(HttpStatusCode.BadRequest, "Token invalido");

        var user = await userService.GetById(userId);

        if (user is null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            throw new SrtException(HttpStatusCode.BadRequest, "Refresh Token invalido o expirado");
        }

        var newAccessToken = GenerateAccessToken(principal.Claims);
        var newRefreshToken = GenerateRefreshTokenString();

        await UpdateUserRefreshToken(user, newRefreshToken);

        return new AuthenticationResponse(newAccessToken, newRefreshToken);
    }

    private async Task UpdateUserRefreshToken(User user, string newRefreshToken)
    {
        user.RefreshToken = newRefreshToken;
        var expiryTime = DateTime.UtcNow.AddDays(1);
        user.RefreshTokenExpiryTime = DateTime.SpecifyKind(expiryTime, DateTimeKind.Unspecified);
        await userService.UpdateUser(user);
    }

    private string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secret = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static string GenerateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private async Task<ClaimsPrincipal?> GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = _appSettings.Audience,
            ValidIssuer = _appSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
            ValidateLifetime = false // ¡Importante! Ignoramos la expiración aquí
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var result = await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);

        if (!result.IsValid)
        {
            return null;
        }

        if (result.SecurityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Token invalido");
        }

        return new ClaimsPrincipal(result.ClaimsIdentity);
    }
}