using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Users;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class UsuarioRolesRepository(SrtConnection srtConnection)
    : Repository<UsuarioRoles>(srtConnection), IUsuarioRolesRepository
{
    public async Task<GetUsuarioRolesResponse> GetRolesUsuario(int usuarioId)
    {
        var result =
            await QuerySpAsync<GetUsuarioRolesQueryResponse>(SpConstants.GetUserRolesByParams,
                new { UserId = usuarioId });
        var listData = result.ToList();
        if (listData.Count == 0)
            return new GetUsuarioRolesResponse();

        return new GetUsuarioRolesResponse
        {
            UsuarioId = listData.First().UsuarioId,
            Roles = listData.Where(x => !string.IsNullOrWhiteSpace(x.Rol)).Select(x => x.Rol!)
        };
    }
}