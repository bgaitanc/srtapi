using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Rutas : BaseEntity
{
    public int RutaID { get; set; }
    public int LocacionOrigenID { get; set; }
    public int LocacionDestinoID { get; set; }
    public decimal DistanciaKM { get; set; }
    public TimeSpan TiempoEstimado { get; set; }
}