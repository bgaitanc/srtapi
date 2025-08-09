using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Paises : BaseEntity
{
    public int PaisID { get; set; }
    public string Pais { get; set; }
}