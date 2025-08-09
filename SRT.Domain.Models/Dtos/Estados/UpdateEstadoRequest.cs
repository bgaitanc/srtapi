namespace SRT.Domain.Models.Dtos.Estados;

public class UpdateEstadoRequest
{
    public required int EstadoId { get; set; }
    public required string EstadoName { get; set; }
}