using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IEstadosRepository : IRepository<Estados>
{
    Task<IEnumerable<Estados>> GetEstados();
    Task<Estados?> GetEstadoByParams(GetEstadoRequest request);
    Task<int> CreateEstado(CreateEstadoRequest request);
    Task<int> UpdateEstado(UpdateEstadoRequest request);
    Task<int> UpdateOrReactiveEstado(int estadoId, bool activo);
}