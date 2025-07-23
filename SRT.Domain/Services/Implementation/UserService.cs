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
        return await _userRepository.GetUserByUserName(request.User);
    }

    public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
    {
        // TODO: se debe validar datos requeridos, considerar fluent validations o
        // el mapper nativo de los controladores ya puede controlar esto,
        // verificar lenguaje de los mensajes
        var users = await _userRepository.GetUserByUserNameAndEmail(request.Usuario, request.Correo);

        if (users is null) return await _userRepository.RegisterUser(request);

        if (users.Usuario == request.Usuario)
        {
            throw new Exception("Usuario ya existe");
        }

        throw new Exception("Correo ya registrado");
    }
}