using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Locaciones;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class LocacionesRepository(SrtConnection srtConnection)
    : Repository<Locaciones>(srtConnection), ILocacionesRepository
{
    public async Task<IEnumerable<Locaciones>> GetLocaciones(int? departamentoId = null)
    {
        var request = new
        {
            DepartamentoId = departamentoId
        };
        return await QuerySpAsync(SpConstants.GetAllLocaciones, request);
    }

    public async Task<Locaciones?> GetLocacionByParams(GetLocacionRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetLocacionByParams, request);
    }

    public async Task<int> CreateLocacion(CreateLocacionRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.DepartamentoId,
            request.LocacionName,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertLocacion, dataToSave);
    }

    public async Task<int> UpdateLocacion(UpdateLocacionRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.LocacionId,
            request.DepartamentoId,
            request.LocacionName,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.UpdateLocacion, dataToSave);
    }

    public async Task<int> UpdateOrReactiveLocacion(int locacionId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            LocacionId = locacionId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactiveLocacion, dataToSave);
    }
}