using SRT.Domain.Models.Dtos.Rutas;

namespace SRT.Domain.Services.Interface;

public interface IRutasService
{
    Task<GetRutaResponse?> GetRuta(GetRutaRequest request);
    Task<IEnumerable<GetRutaResponse>> GetRutas();
    Task<CreateRutaResponse> CreateRuta(CreateRutaRequest request);
    Task<UpdateRutaResponse> UpdateRuta(UpdateRutaRequest request);
    Task EliminarReactivarRuta(int rutaId, bool activo);
}