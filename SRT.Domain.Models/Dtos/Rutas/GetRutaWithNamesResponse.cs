namespace SRT.Domain.Models.Dtos.Rutas;

public class GetRutaWithNamesResponse
{
    public int RutaId { get; set; }
    public int LocacionOrigenId { get; set; }
    public string? LocacionOrigenNombre { get; set; }
    public int LocacionDestinoId { get; set; }
    public string? LocacionDestinoNombre { get; set; }
    public decimal DistanciaKm { get; set; }
    public TimeSpan TiempoEstimado { get; set; }
}
