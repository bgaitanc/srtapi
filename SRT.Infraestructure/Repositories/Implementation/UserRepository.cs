using Dapper;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Auth;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class UserRepository(SrtConnection srtConnection) : Repository<User>, IUserRepository
{
    public async Task<User?> GetUserByUserName(string username)
    {
        // TODO Agregar transacciones (TransactionManager)
        const string sql = "SELECT * FROM Usuarios WHERE Usuario = @Username";
        await using var connection = srtConnection.GetConnection();
        var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
        return user;
    }

    public async Task<List<User>> GetUserByUserNameAndEmail(string username, string email)
    {
        const string sql = "SELECT * FROM Usuarios WHERE Usuario = @Username or Correo = @Correo";
        await using var connection = srtConnection.GetConnection();
        var users = await connection.QueryAsync<User>(sql, new { Username = username, Correo = email });
        return users.ToList();
    }

    public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
    {
        const string sql = """
                           INSERT INTO Usuarios(Nombres, Apellidos, Usuario, Contrasena, Correo, Telefono, FechaCreacion, FechaModificacion, Activo)
                           VALUES (@Nombres, @Apellidos, @Usuario, @Contrasena, @Correo, @Telefono, @FechaCreacion, @FechaModificacion, @Activo);
                           SELECT SCOPE_IDENTITY()
                           """;

        var date = DateTime.Now.Date;

        var dataToSave = new
        {
            request.Nombres,
            request.Apellidos,
            request.Usuario,
            Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena),
            request.Correo,
            request.Telefono,
            FechaCreacion = date,
            //TODO: esto debería de ser nullable
            FechaModificacion = date,
            Activo = true
        };

        await using var connection = srtConnection.GetConnection();
        var result = await connection.ExecuteAsync(sql, dataToSave);

        return new RegisterUserResponse
        {
            UserId = result,
            UserName = request.Usuario
        };
    }
}