namespace SRT.Domain.Models.Dtos.Departamentos;

public class UpdateDepartamentoRequest
{
    public required int DepartamentoId { get; set; }
    public required int PaisId { get; set; }
    public required string DepartamentoName { get; set; }
}