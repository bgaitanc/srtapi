using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class UsuarioRolesService(IUsuarioRolesRepository usuarioRolesRepository) : IUsuarioRolesService
{
    public async Task<GetUsuarioRolesResponse> GetRolesUsuario(int usuarioId)
    {
        return await usuarioRolesRepository.GetRolesUsuario(usuarioId);
    }
}