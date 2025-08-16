using SRT.Domain.Models.Dtos.Users;

namespace SRT.Domain.Services.Interface;

public interface IUsuarioRolesService
{
    Task<GetUsuarioRolesResponse> GetRolesUsuario(int usuarioId);
}