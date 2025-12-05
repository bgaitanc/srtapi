using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class UserRepository(SrtDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetUserByUsername(string username)
    {
        // TODO Agregar transacciones (TransactionManager)
        return await context.Set<User>()
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Rol)
            .FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetUserByUsernameAndEmail(string username, string email)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Username == username && x.Email == email);
    }

    public async Task AssignRoleToUser(Guid userId, Guid roleId)
    {
        var userRole = new UserRol
        {
            UserId = userId,
            RolId = roleId,
            CreatedAt = DateTime.UtcNow
        };
        context.Set<UserRol>().Add(userRole);
        await context.SaveChangesAsync();
    }

    public async Task RemoveRoleFromUser(Guid userId, Guid roleId)
    {
        var userRole = await context.Set<UserRol>()
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RolId == roleId);
        if (userRole != null)
        {
            context.Set<UserRol>().Remove(userRole);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<string>> GetUserRoles(Guid userId)
    {
        var roles = await (from ur in context.Set<UserRol>()
                           join r in context.Set<Rol>() on ur.RolId equals r.Id
                           where ur.UserId == userId
                           select r.Name).ToListAsync();
        return roles;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Set<User>()
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Rol)
            .ToListAsync();
    }
}