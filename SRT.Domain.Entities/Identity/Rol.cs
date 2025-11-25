using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities.Identity;

public class Rol : BaseEntity
{
    public required string Name { get; set; }
}