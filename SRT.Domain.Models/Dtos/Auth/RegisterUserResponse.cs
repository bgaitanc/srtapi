namespace SRT.Domain.Models.Dtos.Auth;

public class RegisterUserResponse
{
    public required Guid Id { get; set; }
    public required string Username { get; set; }
}