using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Departamentos;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class DepartamentosRepository(SrtConnection srtConnection)
    : Repository<Departamentos>(srtConnection), IDepartamentosRepository
{
    public async Task<IEnumerable<Departamentos>> GetDepartamentos(int? paisId = null)
    {
        var request = new
        {
            PaisId = paisId
        };
        return await QuerySpAsync(SpConstants.GetAllDepartamentos, request);
    }

    public async Task<Departamentos?> GetDepartamentoByParams(GetDepartamentoRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetDepartamentoByParams, request);
    }

    public async Task<int> CreateDepartamento(CreateDepartamentoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.PaisId,
            request.DepartamentoName,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertDepartamento, dataToSave);
    }

    public async Task<int> UpdateDepartamento(UpdateDepartamentoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.DepartamentoId,
            request.PaisId,
            request.DepartamentoName,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.UpdateDepartamento, dataToSave);
    }

    public async Task<int> DeleteOrReactiveDepartamento(int departamentoId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            DepartamentoId = departamentoId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactiveDepartamento, dataToSave);
    }
}