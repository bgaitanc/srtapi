using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;

namespace SRT.Domain.Models.Dtos.Users;

public class UserInfoResponse(User user)
{
    public Guid Id { get; set; } = user.Id;
    public string Name { get; set; } = user.Name;
    public string Surname { get; set; } = user.Surname;
    public string Username { get; set; } = user.Username;
    public string Email { get; set; } = user.Email;
    public string? PhoneNumber { get; set; } = user.PhoneNumber;
}