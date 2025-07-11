namespace SRT.Domain.Entities.Base;

public class BaseEntity
{
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CreadorID { get; set; }
    public int ModificadorID { get; set; }
    public bool Activo { get; set; }
}