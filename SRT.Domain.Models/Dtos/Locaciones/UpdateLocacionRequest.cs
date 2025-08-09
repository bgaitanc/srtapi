namespace SRT.Domain.Models.Dtos.Locaciones;

public class UpdateLocacionRequest
{
    public required int LocacionId { get; set; }
    public required int DepartamentoId { get; set; }
    public required string LocacionName { get; set; }
}