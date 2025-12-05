using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;

namespace SRT.Domain.Models.Dtos.Users;

public class UserInfoResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<string> Roles { get; set; } = new();
}