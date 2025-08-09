using SRT.Domain.Models.Dtos.Estados;

namespace SRT.Domain.Models.Dtos.Departamentos;

public class CreateDepartamentoResponse : CreateDepartamentoRequest
{
    public int DepartamentoId { get; set; }
}