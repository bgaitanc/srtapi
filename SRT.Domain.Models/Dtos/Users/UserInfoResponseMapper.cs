using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Users;

namespace SRT.Domain.Models.Dtos.Users;

public static class UserInfoResponseMapper
{
    public static List<string> GetRoleNames(User user)
    {
        return user.UserRoles?.Select(ur => ur.Rol.Name).ToList() ?? new();
    }

    public static UserInfoResponse FromUser(User user)
    {
        return new UserInfoResponse
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Roles = GetRoleNames(user)
        };
    }
}
