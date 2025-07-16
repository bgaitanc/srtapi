using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUserRepository: IRepository<User>
{
    Task<User?> GetUserByUserName(string username);
    Task<List<User>> GetUserByUserNameAndEmail(string requestUsuario, string requestCorreo);
    Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
}   