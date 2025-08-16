namespace SRT.Domain.Models.Dtos.Paises;

public class GetPaisResponse(Entities.Paises pais)
{
    public int PaisId { get; set; } = pais.PaisID;
    public string PaisName { get; set; } = pais.Pais;
    public bool? Activo { get; set; } = pais.Activo;
}