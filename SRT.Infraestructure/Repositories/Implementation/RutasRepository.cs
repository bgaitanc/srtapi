using System.Data;
using Dapper;
using SRT.Domain.Entities;
using SRT.Domain.Entities.Base;
using SRT.Domain.Models.Dtos.Rutas;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class RutasRepository(SrtConnection srtConnection) : Repository<Rutas>(srtConnection), IRutasRepository
{
    public async Task<IEnumerable<Rutas>> GetRutas()
    {
        return await QuerySpAsync(SpConstants.GetAllRutas);
    }
    
    public async Task<IEnumerable<GetRutaWithNamesResponse>> GetRutasWithNames()
    {
        return await QuerySpAsync<GetRutaWithNamesResponse>(SpConstants.GetAllRutas);
    }

    public async Task<Rutas?> GetRutaByParams(GetRutaRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetRutaByParams, request);
    }

    public async Task<int> CreateRuta(CreateRutaRequest request)
    {
        var date = DateTime.Now;
        var parameters = new DynamicParameters();
        parameters.Add(nameof(CreateRutaRequest.LocacionOrigenId), request.LocacionOrigenId, DbType.Int32);
        parameters.Add(nameof(CreateRutaRequest.LocacionDestinoId), request.LocacionDestinoId, DbType.Int32);
        parameters.Add(nameof(CreateRutaRequest.DistanciaKm), request.DistanciaKm, DbType.Decimal, precision: 18,
            scale: 2);
        parameters.Add(nameof(CreateRutaRequest.TiempoEstimado), request.TiempoEstimado, DbType.Time);
        parameters.Add("FechaCreacion", date, DbType.DateTime);
        parameters.Add("CreadorId");

        return await ExecSpAsync(SpConstants.InsertRuta, parameters);
    }

    public async Task<int> UpdateRuta(UpdateRutaRequest request)
    {
        var date = DateTime.Now;
        var parameters = new DynamicParameters();
        parameters.Add(nameof(UpdateRutaRequest.RutaId), request.RutaId, DbType.Int32);
        parameters.Add(nameof(UpdateRutaRequest.LocacionOrigenId), request.LocacionOrigenId, DbType.Int32);
        parameters.Add(nameof(UpdateRutaRequest.LocacionDestinoId), request.LocacionDestinoId, DbType.Int32);
        parameters.Add(nameof(UpdateRutaRequest.DistanciaKm), request.DistanciaKm, DbType.Decimal, precision: 18,
            scale: 2);
        parameters.Add(nameof(UpdateRutaRequest.TiempoEstimado), request.TiempoEstimado, DbType.Time);
        parameters.Add("FechaModificacion", date, DbType.DateTime);
        parameters.Add("ModificadorId");

        return await ExecSpAsync(SpConstants.UpdateRuta, parameters);
    }

    public async Task<int> DeleteOrReactiveRuta(int rutaId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            RutaId = rutaId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactiveRuta, dataToSave);
    }
}