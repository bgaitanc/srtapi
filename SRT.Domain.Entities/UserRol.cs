using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class UserRol : BaseEntity
{
    public required Guid UserId{ get; set; }
    public required Guid RolId { get; set; }
    
    public User User { get; set; }
    public Rol Rol { get; set; }
}