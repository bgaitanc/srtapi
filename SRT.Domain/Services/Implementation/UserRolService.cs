using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class UserRolService(IUserRolRepository userRolesRepository) : IUserRolService
{
    public async Task<GetUserRolesResponse?> GetUserRoles(Guid usuarioId)
    {
        return await userRolesRepository.GetUserRoles(usuarioId);
    }
}