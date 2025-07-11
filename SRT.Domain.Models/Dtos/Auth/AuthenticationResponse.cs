using SRT.Domain.Entities;

namespace SRT.Domain.Models.Dtos.Auth;

public class AuthenticationResponse(User user, string token)
{
    public int Id { get; set; } = user.UsuarioID;
    public string Username { get; set; } = user.Usuario;
    public string Token { get; set; } = token;
}