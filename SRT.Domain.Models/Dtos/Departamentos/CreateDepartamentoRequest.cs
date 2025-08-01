namespace SRT.Domain.Models.Dtos.Departamentos;

public class CreateDepartamentoRequest
{
    public required int PaisId { get; set; }
    public required string DepartamentoName { get; set; }
}