namespace SRT.Domain.Models.Dtos.Auth;

public class AuthenticationResponse(string token, string refreshToken)
{
    public string Token { get; set; } = token;
    public string RefreshToken { get; set; } = refreshToken;
}