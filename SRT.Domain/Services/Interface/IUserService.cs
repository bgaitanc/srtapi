using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;

namespace SRT.Domain.Services.Interface;

public interface IUserService
{
    Task<User?> Authenticate(AuthenticationRequest request);
    Task<RegisterUserResponse> Register(RegisterUserRequest request);
}