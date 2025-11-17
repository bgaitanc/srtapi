using SRT.Domain.Models.Dtos.Users;

namespace SRT.Domain.Services.Interface;

public interface IUserRolService
{
    Task<GetUserRolesResponse?> GetUserRoles(Guid userId);
}