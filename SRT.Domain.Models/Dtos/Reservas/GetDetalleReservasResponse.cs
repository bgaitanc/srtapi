namespace SRT.Domain.Models.Dtos.Reservas;

public class GetDetalleReservasQueryResponse
{
    public int ViajeId { get; set; }
    public int Capacidad { get; set; }
    public int? AsientosReservados { get; set; }
}

public class GetDetalleReservasResponse
{
    public int ViajeId { get; set; }
    public int Capacidad { get; set; }
    public IEnumerable<int> AsientosReservados { get; set; } = [];
}