namespace SRT.Domain.Models.Dtos.Auth;

public class AuthenticationRequest
{
    public required string User { get; set; }

    public required string Password { get; set; }
}