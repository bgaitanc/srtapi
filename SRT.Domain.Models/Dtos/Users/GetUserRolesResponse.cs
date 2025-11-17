namespace SRT.Domain.Models.Dtos.Users;

public class GetUserRolesResponse
{
    public Guid UserId { get; set; }
    public IEnumerable<string> Roles { get; set; } = [];
}