using SRT.Domain.Entities.Identity;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;
using Microsoft.EntityFrameworkCore;

namespace SRT.Infrastructure.Repositories.Implementation;

public class RoleRepository(SrtDbContext context) : Repository<Rol>(context), IRoleRepository
{
    public async Task<Rol> AddAsync(Rol role)
    {
        context.Roles.Add(role);
        await context.SaveChangesAsync();
        return role;
    }

    public async Task<Rol?> GetByIdAsync(Guid id)
    {
        return await context.Roles.FindAsync(id);
    }

    public async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await context.Roles.ToListAsync();
    }

    public async Task<Rol> UpdateAsync(Rol role)
    {
        context.Roles.Update(role);
        await context.SaveChangesAsync();
        return role;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var role = await context.Roles.FindAsync(id);
        if (role == null) return false;
        context.Roles.Remove(role);
        await context.SaveChangesAsync();
        return true;
    }
}
