using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Departamentos;
using SRT.Domain.Repositories.Interface.Base;

namespace SRT.Domain.Repositories.Interface;

public interface IDepartamentosRepository : IRepository<Departamentos>
{
    Task<IEnumerable<Departamentos>> GetDepartamentos(int? paisId);
    Task<Departamentos?> GetDepartamentoByParams(GetDepartamentoRequest request);
    Task<int> CreateDepartamento(CreateDepartamentoRequest request);
    Task<int> UpdateDepartamento(UpdateDepartamentoRequest request);
    Task<int> DeleteOrReactiveDepartamento(int departamentoId, bool activo);
}