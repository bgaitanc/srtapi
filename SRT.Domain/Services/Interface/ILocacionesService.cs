using SRT.Domain.Models.Dtos.Locaciones;

namespace SRT.Domain.Services.Interface;

public interface ILocacionesService
{
    Task<GetLocacionResponse?> GetLocacion(GetLocacionRequest request);
    Task<IEnumerable<GetLocacionResponse>> GetLocaciones(int? departamentoId);
    Task<CreateLocacionResponse> CreateLocacion(CreateLocacionRequest request);
    Task<UpdateLocacionResponse> UpdateLocacion(UpdateLocacionRequest request);
    Task EliminarReactivarLocacion(int locacionId, bool activo);
}