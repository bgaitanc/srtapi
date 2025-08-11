using SRT.Domain.Entities.Base;

namespace SRT.Domain.Models.Dtos.Rutas;

public class CreateRutaRequest
{
    public required int LocacionOrigenId { get; set; }
    public required int LocacionDestinoId { get; set; }
    public required decimal DistanciaKm { get; set; }
    public required TimeSpan TiempoEstimado { get; set; }
}