using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Dtos.Users;

namespace SRT.Domain.Services.Interface;

public interface IUserService
{
    Task<User?> GetUser(string username);
    Task<User?> GetById(Guid id);
    Task UpdateUser(User user);
    Task<UserInfoResponse> GetUserInfo(string username);
    Task<RegisterUserResponse> Register(RegisterUserRequest request);
    Task AssignRoleToUser(Guid userId, Guid roleId);
    Task RemoveRoleFromUser(Guid userId, Guid roleId);
    Task<IEnumerable<string>> GetUserRoles(Guid userId);
    Task<IEnumerable<UserInfoResponse>> GetAllUsers();
    Task<UserInfoResponse> UpdateUserProfile(Guid userId, UpdateUserProfileRequest request);
}