using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class UsuarioRoles : BaseEntity
{
    public int UsuarioRolID { get; set; }
    public int UsuarioID { get; set; }
    public int RolID { get; set; }
    public DateTime FechaAsignacion { get; set; }
}