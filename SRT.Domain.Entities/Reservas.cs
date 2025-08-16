using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Reservas : BaseEntity
{
    public int ReservaID { get; set; }
    public int ViajeID { get; set; }
    public int ClienteID { get; set; }
    public DateTime FechaReserva { get; set; }
}