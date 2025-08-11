using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Rutas;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IRutasRepository : IRepository<Rutas>
{
    Task<IEnumerable<Rutas>> GetRutas();
    Task<Rutas?> GetRutaByParams(GetRutaRequest request);
    Task<int> CreateRuta(CreateRutaRequest request);
    Task<int> UpdateRuta(UpdateRutaRequest request);
    Task<int> DeleteOrReactiveRuta(int rutaId, bool activo);
}