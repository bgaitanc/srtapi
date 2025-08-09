using System.ComponentModel.DataAnnotations;

namespace SRT.Domain.Models.Dtos.Vehiculos;

public class UpdateVehiculoRequest
{
    public required int VehiculoId { get; set; }
    [MaxLength(20)] public required string Placa { get; set; }
    [MaxLength(100)] public required string Modelo { get; set; }
    public required int Capacidad { get; set; }
}