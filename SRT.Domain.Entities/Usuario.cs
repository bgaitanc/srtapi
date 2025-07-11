using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class User : BaseEntity
{
    public int UsuarioID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Usuario { get; set; }
    public string Contrasenia { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public int RolId { get; set; }
}