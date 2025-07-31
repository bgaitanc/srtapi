using SRT.Domain.Models.Dtos.Estados;

namespace SRT.Domain.Services.Interface;

public interface IEstadoService
{
    Task<GetEstadoResponse?> GetEstado(GetEstadoRequest request);
    Task<IEnumerable<GetEstadoResponse>> GetEstados();
    Task<CreateEstadoResponse> CreateEstado(CreateEstadoRequest request);
    Task<UpdateEstadoResponse> UpdateEstado(UpdateEstadoRequest request);
    Task EliminarReactivarEstado(int estadoId, bool activo);
}