namespace SRT.Domain.Models.Dtos.Viajes;

public class GetViajesResponse
{
    public int ViajeId { get; set; }
    public int RutaId { get; set; }
    public int VehiculoId { get; set; }
    public int ConductorId { get; set; }
    public decimal Costo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
    public int EstadoId { get; set; }

    //Navigations
    public RutaInfo Ruta { get; set; }
    public VehiculoInfo Vehiculo { get; set; }
    public ConductorInfo Conductor { get; set; }
    public string Estado { get; set; }
}

public class RutaInfo
{
    public string LocacionOrigen { get; set; }
    public string LocacionDestino { get; set; }
    public decimal DistanciaKM { get; set; }
    public TimeSpan TiempoEstimado { get; set; }
}

public class VehiculoInfo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Capacidad { get; set; }
}

public class ConductorInfo
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
}