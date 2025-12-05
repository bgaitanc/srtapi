namespace SRT.Domain.Models.Dtos.Users;

public class RemoveUserRoleRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}

