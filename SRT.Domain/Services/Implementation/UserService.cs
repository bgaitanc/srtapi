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
        return new UserInfoResponse(user!);
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
                Email = request.Email
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
}