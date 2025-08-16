using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Roles : BaseEntity
{
    public int RolID { get; set; }
    public string Rol { get; set; }
}