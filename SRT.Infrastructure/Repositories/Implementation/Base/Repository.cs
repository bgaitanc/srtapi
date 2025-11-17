using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities.Base;
using SRT.Domain.Repositories.Interface.Base;
using SRT.Infrastructure.Database;

namespace SRT.Infrastructure.Repositories.Implementation.Base;

public class Repository<T>(SrtDbContext context) : IRepository<T> where T : BaseEntity
{
    public IQueryable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetAllTracking()
    {
        return context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> GetByIdTrackingAsync(Guid id)
    {
        return await GetAllTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}