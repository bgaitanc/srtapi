using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Estados : BaseEntity
{
    public int EstadoID { get; set; }
    public string Estado { get; set; }
}