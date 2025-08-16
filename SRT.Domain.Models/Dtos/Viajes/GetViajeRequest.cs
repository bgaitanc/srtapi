namespace SRT.Domain.Models.Dtos.Viajes;

public class GetViajeRequest
{
    public int? ViajeId { get; set; }
    public int? RutaId { get; set; }
    public int? VehiculoId { get; set; }
    public int? ConductorId { get; set; }
}