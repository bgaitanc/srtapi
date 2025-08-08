using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Paises;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IPaisesRepository : IRepository<Paises>
{
    Task<IEnumerable<Paises>> GetPaises();
    Task<Paises?> GetPaisByParams(GetPaisRequest request);
    Task<int> CreatePais(CreatePaisRequest request);
    Task<int> UpdatePais(UpdatePaisRequest request);
    Task<int> DeleteOrReactivePais(int paisId, bool activo);
}