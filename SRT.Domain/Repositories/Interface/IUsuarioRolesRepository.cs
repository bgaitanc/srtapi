using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IUsuarioRolesRepository : IRepository<UsuarioRoles>
{
    Task<GetUsuarioRolesResponse> GetRolesUsuario(int usuarioId);
}