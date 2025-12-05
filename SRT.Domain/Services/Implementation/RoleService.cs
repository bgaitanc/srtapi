using SRT.Domain.Entities.Identity;
using SRT.Domain.Models.Dtos.Roles;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<RoleDto> CreateRoleAsync(CreateRoleRequest request)
    {
        var role = new Rol
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTime.UtcNow
        };
        var created = await roleRepository.AddAsync(role);
        return created.ToDto();
    }

    public async Task<RoleDto> UpdateRoleAsync(UpdateRoleRequest request)
    {
        var role = await roleRepository.GetByIdAsync(request.Id);
        if (role == null) throw new Exception("Role not found");
        role.Name = request.Name;
        role.UpdatedAt = DateTime.UtcNow;
        var updated = await roleRepository.UpdateAsync(role);
        return updated.ToDto();
    }

    public async Task<bool> DeleteRoleAsync(DeleteRoleRequest request)
    {
        return await roleRepository.DeleteAsync(request.Id);
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await roleRepository.GetAllAsync();
        return roles.Select(r => r.ToDto());
    }

    public async Task<RoleDto?> GetRoleByIdAsync(Guid id)
    {
        var role = await roleRepository.GetByIdAsync(id);
        return role?.ToDto();
    }
}
