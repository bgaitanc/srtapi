namespace SRT.Domain.Models.Dtos.Auth;

public class RegisterUserResponse
{
    public int UserId { get; set; }
    public required string UserName { get; set; }
}