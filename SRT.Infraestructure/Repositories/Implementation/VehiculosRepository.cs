using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class VehiculosRepository(SrtConnection srtConnection)
    : Repository<Vehiculos>(srtConnection), IVehiculosRepository
{
    public async Task<IEnumerable<Vehiculos>> GetVehiculos()
    {
        return await QuerySpAsync(SpConstants.GetAllVehiculos);
    }

    public async Task<Vehiculos?> GetVehiculoByParams(GetVehiculoRequest request)
    {
        return await GetFirstOrDefaultSpAsync(SpConstants.GetVehiculoByParams, request);
    }

    public async Task<int> CreateVehiculo(CreateVehiculoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.Placa,
            request.Modelo,
            request.Capacidad,
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertVehiculo, dataToSave);
    }

    public async Task<int> UpdateVehiculo(UpdateVehiculoRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.VehiculoId,
            request.Placa,
            request.Modelo,
            request.Capacidad,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.UpdateVehiculo, dataToSave);
    }

    public async Task<int> DeleteOrReactiveVehiculo(int vehiculoId, bool activo)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            VehiculoId = vehiculoId,
            Activo = activo,
            FechaModificacion = date,
            ModificadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.DeleteOrReactiveVehiculo, dataToSave);
    }
}