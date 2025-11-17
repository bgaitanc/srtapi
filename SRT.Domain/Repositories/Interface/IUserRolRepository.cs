using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUserRolRepository : IRepository<UserRol>
{
    Task<GetUserRolesResponse?> GetUserRoles(Guid userId);
}