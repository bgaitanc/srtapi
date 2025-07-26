using Dapper;
using SRT.Domain.Entities.Base;
using SRT.Domain.Repositories.Interface.Base;
using SRT.Infraestructure.Database;

namespace SRT.Infraestructure.Repositories.Implementation.Base;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly SrtConnection _srtConnection;

    protected Repository(SrtConnection srtConnection)
    {
        _srtConnection = srtConnection;
    }

    public async Task<T?> GetFirstOrDefaultAsync(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
    }

    public async Task<int> ExecAsync(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.ExecuteScalarAsync<int>(sql, param);
    }
}