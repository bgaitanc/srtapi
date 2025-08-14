namespace SRT.Domain.Models.Dtos.Departamentos;

public class GetDepartamentoResponse(Entities.Departamentos departamento)
{
    public int DepartamentoId { get; set; } = departamento.DepartamentoID;
    public int PaisId { get; set; } = departamento.PaisID;
    public string DepartamentoName { get; set; } = departamento.Departamento;
    public bool? Activo { get; set; } = departamento.Activo;
}