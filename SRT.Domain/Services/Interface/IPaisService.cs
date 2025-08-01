using SRT.Domain.Models.Dtos.Paises;

namespace SRT.Domain.Services.Interface;

public interface IPaisService
{
    Task<GetPaisResponse?> GetPais(GetPaisRequest request);
    Task<IEnumerable<GetPaisResponse>> GetPaises();
    Task<CreatePaisResponse> CreatePais(CreatePaisRequest request);
    Task<UpdatePaisResponse> UpdatePais(UpdatePaisRequest request);
    Task EliminarReactivarPais(int paisId, bool activo);
}