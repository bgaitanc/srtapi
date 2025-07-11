using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Authenticate(AuthenticationRequest request)
    {
        return await _userRepository.GetUser(request.User, request.Password);
    }
}