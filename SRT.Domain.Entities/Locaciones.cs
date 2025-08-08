using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Locaciones : BaseEntity
{
    public int DestinoID { get; set; }
    public int DepartamentoID { get; set; }
    public string Locacion { get; set; }
}