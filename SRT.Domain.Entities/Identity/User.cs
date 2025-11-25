using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities.Identity;

public class User : BaseEntity
{
    public required string Name { get; set; }

    public required string Surname { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public required string Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }
}