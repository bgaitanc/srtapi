using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Paises;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class PaisesRepository(SrtConnection srtConnection) : Repository<Paises>(srtConnection), IPaisesRepository
{
    public async Task<IEnumerable<Paises>> GetPaises()
    {
        return await QuerySpAsync(SpConstants.GetAllPaises);
    }

    public async Task<Paises?> GetPaisByParams(GetPaisRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetPaisByParams, request);
    }

    public async Task<int> CreatePais(CreatePaisRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.PaisName,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertPais, dataToSave);
    }

    public async Task<int> UpdatePais(UpdatePaisRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.PaisId,
            request.PaisName,
            FechaModificacion = date,
            ModificadorID = default(int?)
        };

        return await ExecSpAsync(SpConstants.UpdatePais, dataToSave);
    }

    public async Task<int> UpdateOrReactivePais(int paisId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            PaisId = paisId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactivePais, dataToSave);
    }
}