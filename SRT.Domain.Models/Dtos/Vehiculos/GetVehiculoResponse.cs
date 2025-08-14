namespace SRT.Domain.Models.Dtos.Vehiculos;

public class GetVehiculoResponse(Entities.Vehiculos vehiculo)
{
    public int VehiculoId { get; set; } = vehiculo.VehiculoID;
    public string Placa { get; set; } = vehiculo.Placa;
    public string Modelo { get; set; } = vehiculo.Modelo;
    public int Capacidad { get; set; } = vehiculo.Capacidad;
    public bool? Activo { get; set; } = vehiculo.Activo;
}