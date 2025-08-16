namespace SRT.Domain.Models.Dtos.Reservas;

public class CreateReservaRequest
{
    public int ViajeId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaReserva { get; set; }
    public required List<int> Detalle { get; set; }
}