namespace SRT.Domain.Models.Dtos.Auth;

public class AuthenticationResponse(string token)
{
    public string Token { get; set; } = token;
}