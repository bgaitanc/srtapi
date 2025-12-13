using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetUser(string username)
    {
        return await userRepository.GetUserByUsername(username);
    }

    public async Task<User?> GetById(Guid id)
    {
        return await userRepository.GetByIdTrackingAsync(id);
    }

    public async Task UpdateUser(User user)
    {
        await userRepository.UpdateAsync(user);
    }

    public async Task<UserInfoResponse> GetUserInfo(string username)
    {
        var user = await GetUser(username);
        return UserInfoResponseMapper.FromUser(user!);
    }

    public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
    {
        // TODO: Required data must be validated, consider fluent validations or
        // the native mapper of the controllers can already control this,
        // verify the language of the messages.
        var users = await userRepository.GetUserByUsernameAndEmail(request.Username, request.Email);

        if (users is null)
        {
            //TODO AutoMapper????
            var newUser = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var result = await userRepository.CreateAsync(newUser);
            return new RegisterUserResponse
            {
                Id = result.Id,
                Username = request.Username
            };
        }

        if (users.Username == request.Username)
        {
            throw new Exception("Usuario ya existe");
        }

        throw new Exception("Correo ya registrado");
    }
    
    public async Task AssignRoleToUser(Guid userId, Guid roleId)
    {
        await userRepository.AssignRoleToUser(userId, roleId);
    }

    public async Task RemoveRoleFromUser(Guid userId, Guid roleId)
    {
        await userRepository.RemoveRoleFromUser(userId, roleId);
    }

    public async Task<IEnumerable<string>> GetUserRoles(Guid userId)
    {
        return await userRepository.GetUserRoles(userId);
    }

    public async Task<IEnumerable<UserInfoResponse>> GetAllUsers()
    {
        var users = await userRepository.GetAllAsync();
        return users.Select(UserInfoResponseMapper.FromUser);
    }

    public async Task<UserInfoResponse> UpdateUserProfile(Guid userId, UpdateUserProfileRequest request)
    {
        var user = await userRepository.GetByIdTrackingAsync(userId);
        if (user == null)
            throw new Exception("Usuario no encontrado");

        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;

        await userRepository.UpdateAsync(user);
        return UserInfoResponseMapper.FromUser(user);
    }
}