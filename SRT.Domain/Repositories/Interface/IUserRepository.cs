using SRT.Domain.Entities;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByUsername(string username);
    Task<User?> GetUserByUsernameAndEmail(string username, string email);
}