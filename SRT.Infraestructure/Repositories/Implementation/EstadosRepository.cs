using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class EstadosRepository(SrtConnection srtConnection) : Repository<Estados>(srtConnection), IEstadosRepository
{
    public async Task<IEnumerable<Estados>> GetEstados()
    {
        return await QuerySpAsync(SpConstants.GetAllEstados);
    }

    public async Task<Estados?> GetEstadoByParams(GetEstadoRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetEstadoByParams, request);
    }

    public async Task<int> CreateEstado(CreateEstadoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.EstadoName,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertEstado, dataToSave);
    }

    public async Task<int> UpdateEstado(UpdateEstadoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.EstadoId,
            request.EstadoName,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.UpdateEstado, dataToSave);
    }

    public async Task<int> DeleteOrReactiveEstado(int estadoId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            EstadoId = estadoId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactiveEstado, dataToSave);
    }
}