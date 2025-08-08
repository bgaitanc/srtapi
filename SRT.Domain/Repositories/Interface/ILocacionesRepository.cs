using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Locaciones;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface ILocacionesRepository : IRepository<Locaciones>
{
    Task<IEnumerable<Locaciones>> GetLocaciones(int? departamentoId);
    Task<Locaciones?> GetLocacionByParams(GetLocacionRequest request);
    Task<int> CreateLocacion(CreateLocacionRequest request);
    Task<int> UpdateLocacion(UpdateLocacionRequest request);
    Task<int> UpdateOrReactiveLocacion(int locacionId, bool activo);
}