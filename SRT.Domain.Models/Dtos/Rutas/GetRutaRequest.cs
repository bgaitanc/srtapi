namespace SRT.Domain.Models.Dtos.Rutas;

public class GetRutaRequest
{
    public int? RutaId { get; set; }
    public int? LocacionOrigenId { get; set; }
    public int? LocacionDestinoId { get; set; }
}