namespace SRT.Domain.Models.Dtos.Users;

public class AssignUserRoleRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}

