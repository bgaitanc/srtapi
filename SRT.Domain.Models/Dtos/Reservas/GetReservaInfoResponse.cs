using SRT.Domain.Models.Dtos.Viajes;

namespace SRT.Domain.Models.Dtos.Reservas;

public class GetReservaInfoResponse
{
    public int ReservaId { get; set; }
    public int ViajeId { get; set; }
    public DateTime FechaReserva { get; set; }
    public IEnumerable<CreateDetalleReservaResponse> Detalle { get; set; } = [];
    public GetViajeInfoResponse Viaje { get; set; }
    public RutaInfo Ruta { get; set; }
    public decimal Total { get; set; }
}