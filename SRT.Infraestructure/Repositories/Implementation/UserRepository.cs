using Dapper;
using SRT.Domain.Entities;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly SrtConnection _srtConnection;

    public UserRepository(SrtConnection srtConnection)
    {
        _srtConnection = srtConnection;
    }

    public async Task<User?> GetUser(string username, string password)
    {
        // TODO Agregar transacciones (TransactionManager)
        const string sql = "SELECT * FROM Usuarios WHERE Usuario = @Username and Contrasena = @Password";
        await using var connection = _srtConnection.GetConnection();
        var user = await connection.QuerySingleAsync<User>(sql, new { Username = username, Password = password });
        return user;
    }
}