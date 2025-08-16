namespace SRT.Domain.Models.Dtos.Reservas;

public class CreateReservaResponse
{
    public int ReservaId { get; set; }
    public int ViajeId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaReserva { get; set; }
    public IEnumerable<CreateDetalleReservaResponse> Detalle { get; set; } = [];
}