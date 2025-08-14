using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehiculos;
using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class ViajesRepository(SrtConnection srtConnection) : Repository<Viajes>(srtConnection), IViajesRepository
{
    public async Task<IEnumerable<GetViajesResponse>> GetViajes()
    {
        return await QueryMultipleSpAsync(SpConstants.GetAllViajes, [
            typeof(GetViajesResponse),
            typeof(RutaInfo),
            typeof(VehiculoInfo),
            typeof(ConductorInfo),
            typeof(Estados)
        ], MapAction(), "RutaID,VehiculoID,ConductorID,EstadoID");

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

    public Task<Vehiculos?> GetVehiculoByParams(GetVehiculoRequest request)
    {
        throw new NotImplementedException();
    }
}