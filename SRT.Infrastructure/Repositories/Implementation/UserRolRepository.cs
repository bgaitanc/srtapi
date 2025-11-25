using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class UserRolRepository(SrtDbContext context) : Repository<UserRol>(context), IUserRolRepository
{
    public async Task<GetUserRolesResponse?> GetUserRoles(Guid userId)
    {
        return await GetAll().Include(ur => ur.User).Include(ur => ur.Rol)
            .GroupBy(ur => ur.UserId)
            .Select(x => new GetUserRolesResponse
            {
                UserId = x.Key,
                Roles = x.Select(y => y.Rol.Name)
            })
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}