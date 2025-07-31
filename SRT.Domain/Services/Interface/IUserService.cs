using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Dtos.Users;

namespace SRT.Domain.Services.Interface;

public interface IUserService
{
    Task<User?> GetUser(string username);
    Task<UserInfoResponse> GetUserInfo(string username);
    Task<RegisterUserResponse> Register(RegisterUserRequest request);
}