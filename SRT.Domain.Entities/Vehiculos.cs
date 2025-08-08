using System.ComponentModel.DataAnnotations;
using SRT.Domain.Entities.Base;

namespace SRT.Domain.Entities;

public class Vehiculos : BaseEntity
{
    public int VehiculoID { get; set; }
    [MaxLength(20)] public string Placa { get; set; }
    [MaxLength(100)] public string Modelo { get; set; }
    public int Capacidad { get; set; }
}