using System.Data;
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

    #region Sp

    public async Task<IEnumerable<T>> QuerySpAsync(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }

    protected async Task<IEnumerable<T>> QuerySpAsync<T>(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }

    public async Task<T?> GetFirstOrDefaultSpAsync(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> ExecSpAsync(string sql, object? param = null)
    {
        await using var connection = _srtConnection.GetConnection();
        return await connection.ExecuteScalarAsync<int>(sql, param, commandType: CommandType.StoredProcedure);
    }

    #endregion

    #region RawSql

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

    #endregion
}