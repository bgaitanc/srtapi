using SRT.Domain.Entities.Identity;

namespace SRT.Domain.Models.Dtos.Roles;

public static class RoleMapper
{
    public static RoleDto ToDto(this Rol rol)
    {
        return new RoleDto
        {
            Id = rol.Id,
            Name = rol.Name,
            CreatedAt = rol.CreatedAt,
            CreatedBy = rol.CreatedBy,
            UpdatedAt = rol.UpdatedAt,
            UpdatedBy = rol.UpdatedBy
        };
    }
}

