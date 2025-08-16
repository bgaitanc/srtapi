namespace SRT.Domain.Models.Dtos.Locaciones;

public class GetLocacionResponse(Entities.Locaciones locacion)
{
    public int LocacionId { get; set; } = locacion.DestinoID;
    public int DepartamentoId { get; set; } = locacion.DepartamentoID;
    public string LocacionName { get; set; } = locacion.Locacion;
    public bool? Activo { get; set; } = locacion.Activo;
}