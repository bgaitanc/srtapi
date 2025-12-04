using SRT.Domain.Models.Dtos.Roles;

namespace SRT.Domain.Services.Interface
{
    public interface IRoleService
    {
        Task<RoleDto> CreateRoleAsync(CreateRoleRequest request);
        Task<RoleDto> UpdateRoleAsync(UpdateRoleRequest request);
        Task<bool> DeleteRoleAsync(DeleteRoleRequest request);
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto?> GetRoleByIdAsync(Guid id);
    }
}
