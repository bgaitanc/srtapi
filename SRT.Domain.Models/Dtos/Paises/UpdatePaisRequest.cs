namespace SRT.Domain.Models.Dtos.Paises;

public class UpdatePaisRequest
{
    public required int PaisId { get; set; }
    public required string PaisName { get; set; }
}