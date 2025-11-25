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
        return await GetAll().FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetUserByUsernameAndEmail(string username, string email)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Username == username && x.Email == email);
    }
}