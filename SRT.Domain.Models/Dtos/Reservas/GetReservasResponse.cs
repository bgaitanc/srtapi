namespace SRT.Domain.Models.Dtos.Reservas;

public class GetReservasResponse
{
    public int ReservaId { get; set; }
    public int ViajeId { get; set; }
    public DateTime FechaReserva { get; set; }
    public List<int> Detalle { get; set; } = [];
}