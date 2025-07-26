using SRT.Domain.Models.Dtos.Estados;

namespace SRT.Domain.Services.Interface;

public interface IEstadoService
{
    Task<GetEstadoResponse> GetEstado(GetEstadoRequest request);
}