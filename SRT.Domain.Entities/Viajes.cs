using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Viajes : BaseEntity
{
    public int ViajeID { get; set; }
    public int RutaID { get; set; }
    public int VehiculoID { get; set; }
    public int Conductor { get; set; }
    public decimal Costo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
}
