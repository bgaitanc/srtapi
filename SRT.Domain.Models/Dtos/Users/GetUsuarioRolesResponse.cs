namespace SRT.Domain.Models.Dtos.Users;

public class GetUsuarioRolesResponse
{
    public int UsuarioId { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
}