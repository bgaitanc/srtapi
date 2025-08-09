using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

//TODO es necesario esta entidad? los estados de los registros
// se podrían manejar mediante Flags
public class Estados : BaseEntity
{
    public int EstadoID { get; set; }
    public string Estado { get; set; }
}