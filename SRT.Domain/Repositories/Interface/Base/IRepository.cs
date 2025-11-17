using SRT.Domain.Entities.Base;

namespace SRT.Domain.Repositories.Interface.Base;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    IQueryable<T> GetAllTracking();

    Task<T?> GetByIdAsync(Guid id);

    Task<T?> GetByIdTrackingAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}