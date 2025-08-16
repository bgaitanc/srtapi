using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class DetalleReservas : BaseEntity
{
    public int DetalleReservaID { get; set; }
    public int ReservaID { get; set; }
    public int NumeroAsiento { get; set; }
}