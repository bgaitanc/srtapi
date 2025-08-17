namespace SRT.Domain.Models.Dtos.Viajes;

public class GetViajeInfoResponse
{
    public decimal Costo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
}