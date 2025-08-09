namespace SRT.Domain.Models.Dtos.Auth;

public class RegisterUserRequest
{
    public required string Nombres { get; set; }
    public required string Apellidos { get; set; }
    public required string Usuario { get; set; }
    public required string Contrasena { get; set; }
    public required string Correo { get; set; }
    public required string Telefono { get; set; }
}