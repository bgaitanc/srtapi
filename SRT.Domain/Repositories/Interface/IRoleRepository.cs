using SRT.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRT.Domain.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<Rol> AddAsync(Rol role);
        Task<Rol?> GetByIdAsync(Guid id);
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol> UpdateAsync(Rol role);
        Task<bool> DeleteAsync(Guid id);
    }
}

