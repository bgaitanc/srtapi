namespace SRT.Domain.Models.Dtos.Roles;

public class CreateRoleRequest
{
    public string Name { get; set; }
}

public class UpdateRoleRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class DeleteRoleRequest
{
    public Guid Id { get; set; }
}

