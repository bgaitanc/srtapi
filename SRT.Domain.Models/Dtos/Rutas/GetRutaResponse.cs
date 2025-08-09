namespace SRT.Domain.Models.Dtos.Rutas;

public class GetRutaResponse(Entities.Rutas ruta)
{
    public int RutaId { get; set; } = ruta.RutaID;
    public int LocacionOrigenId { get; set; } = ruta.LocacionOrigenID;
    public int LocacionDestinoId { get; set; } = ruta.LocacionDestinoID;
    public decimal DistanciaKm { get; set; } = ruta.DistanciaKM;
    public TimeSpan TiempoEstimado { get; set; } = ruta.TiempoEstimado;
}