using SRT.Domain.Entities;

namespace SRT.Domain.Models.Dtos.Users;

public class UserInfoResponse(User user)
{
    public int UsuarioId { get; set; } = user.UsuarioID;
    public string Nombres { get; set; } = user.Nombres;
    public string Apellidos { get; set; } = user.Apellidos;
    public string Usuario { get; set; } = user.Usuario;
    public string Correo { get; set; } = user.Correo;
    public string Telefono { get; set; } = user.Telefono;
}