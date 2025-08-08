namespace SRT.Domain.Models.Dtos.Locaciones;

public class CreateLocacionRequest
{
    public required int DepartamentoId { get; set; }
    public required string LocacionName { get; set; }
}