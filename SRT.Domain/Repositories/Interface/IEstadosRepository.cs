using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IEstadosRepository : IRepository<Estados>
{
    Task<Estados?> GetEstadoById(int estadoId);
    Task<Estados?> GetEstadoByName(string estadoName);
    Task<RegisterEstadoResponse> RegisterEstado(RegisterEstadoRequest request);
}