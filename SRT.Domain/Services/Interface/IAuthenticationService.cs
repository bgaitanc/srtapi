using SRT.Domain.Models.Dtos.Auth;

namespace SRT.Domain.Services.Interface;

public interface IAuthenticationService
{
    Task<AuthenticationResponse?> GenerateToken(AuthenticationRequest request);
}