using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class UserRepository(SrtConnection srtConnection) : Repository<User>(srtConnection), IUserRepository
{
    public async Task<User?> GetUserByUserName(string username)
    {
        // TODO Agregar transacciones (TransactionManager)
        return await GetFirstOrDefaultAsync(SpConstants.GetUserByUserName, new { Username = username });
    }

    public async Task<User?> GetUserByUserNameAndEmail(string username, string email)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetUserByUserNameAndEmail,
            new { Username = username, Correo = email });
    }

    public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
    {
        var date = DateTime.Now;

        var dataToSave = new
        {
            request.Nombres,
            request.Apellidos,
            request.Usuario,
            Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena),
            request.Correo,
            request.Telefono,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        var result = await ExecSpAsync(SpConstants.InsertUser, dataToSave);

        return new RegisterUserResponse
        {
            UserId = result,
            UserName = request.Usuario
        };
    }
}