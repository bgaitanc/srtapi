using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class ViajesRepository(SrtConnection srtConnection) : Repository<Viajes>(srtConnection), IViajesRepository
{
    public async Task<IEnumerable<GetViajesResponse>> GetViajes(int? viajeId = null)
    {
        return await QueryMultipleSpAsync(SpConstants.GetAllViajes, [
            typeof(GetViajesResponse),
            typeof(RutaInfo),
            typeof(VehiculoInfo),
            typeof(ConductorInfo),
            typeof(Estados)
        ], MapAction(), "RutaID,VehiculoID,ConductorID,EstadoID", new { ViajeId = viajeId });

        Func<object[], GetViajesResponse> MapAction()
        {
            return objs =>
            {
                var currentRoot = objs[0] as GetViajesResponse;
                currentRoot!.Ruta = (objs[1] as RutaInfo)!;
                currentRoot.Vehiculo = (objs[2] as VehiculoInfo)!;
                currentRoot.Conductor = (objs[3] as ConductorInfo)!;
                currentRoot.Estado = (objs[4] as Estados)!.Estado;

                return currentRoot;
            };
        }
    }

    public async Task<GetViajesResponse?> GetViajeById(int viajeId)
    {
        var result = await GetViajes(viajeId);
        return result.FirstOrDefault();
    }

    public async Task<int> CreateViaje(CreateViajeRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.RutaId,
            request.VehiculoId,
            request.ConductorId,
            request.Costo,
            request.FechaHoraLlegada,
            request.FechaHoraSalida,
            EstadoId = 4, //Pendiente?
            FechaCreacion = date,
            CreadorId = default(int?)
        };

        return await ExecSpAsync(SpConstants.InsertViaje, dataToSave);
    }
}