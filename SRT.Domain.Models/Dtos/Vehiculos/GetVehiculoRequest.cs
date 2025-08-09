namespace SRT.Domain.Models.Dtos.Vehiculos;

public class GetVehiculoRequest
{
    public int? VehiculoId { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
}