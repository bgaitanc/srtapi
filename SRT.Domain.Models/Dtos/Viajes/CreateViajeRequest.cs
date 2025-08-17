namespace SRT.Domain.Models.Dtos.Viajes;

public class CreateViajeRequest
{
    public int RutaId { get; set; }
    public int VehiculoId { get; set; }
    public int ConductorId { get; set; }
    public decimal Costo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
}