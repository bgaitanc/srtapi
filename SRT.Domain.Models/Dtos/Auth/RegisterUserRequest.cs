namespace SRT.Domain.Models.Dtos.Auth;

public class RegisterUserRequest
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
}