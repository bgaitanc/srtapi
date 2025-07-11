using SRT.Domain.Entities;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUserRepository: IRepository<User>
{
    Task<User?> GetUser(string username, string password);
}