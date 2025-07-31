namespace SRT.Domain.Models.Dtos.Estados;

public class GetEstadoResponse(Entities.Estados estado)
{
    public int EstadoId { get; set; } = estado.EstadoID;
    public string EstadoName { get; set; } = estado.Estado;
    public bool Activo { get; set; } = estado.Activo;
}