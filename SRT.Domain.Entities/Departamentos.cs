using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Departamentos : BaseEntity
{
    public int DepartamentoID { get; set; }
    public int PaisID { get; set; }
    public string Departamento { get; set; }
}