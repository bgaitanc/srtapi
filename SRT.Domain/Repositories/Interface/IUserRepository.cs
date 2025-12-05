using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByUsername(string username);
    Task<User?> GetUserByUsernameAndEmail(string username, string email);
    Task AssignRoleToUser(Guid userId, Guid roleId);
    Task RemoveRoleFromUser(Guid userId, Guid roleId);
    Task<IEnumerable<string>> GetUserRoles(Guid userId);
    Task<IEnumerable<User>> GetAllAsync();
}