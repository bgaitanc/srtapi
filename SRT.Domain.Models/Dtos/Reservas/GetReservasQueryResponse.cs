namespace SRT.Domain.Models.Dtos.Reservas;

public class GetReservasQueryResponse
{
    public int ReservaId { get; set; }
    public int ViajeId { get; set; }
    public DateTime FechaReserva { get; set; }
    public int NumeroAsiento { get; set; }
}