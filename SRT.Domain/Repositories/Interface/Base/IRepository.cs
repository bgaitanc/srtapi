using SRT.Domain.Entities.Base;

namespace SRT.Domain.Repositories.Interface.Base;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetFirstOrDefaultAsync(string sql, object? param = null);
    
    Task<int> ExecAsync(string sql, object? param = null);
}