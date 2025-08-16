using System.Data;
using Dapper;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class DetalleReservasRepository(SrtConnection srtConnection)
    : Repository<DetalleReservas>(srtConnection), IDetalleReservasRepository
{
    public async Task<GetDetalleReservasResponse> GetDetalleReservasByViajeId(int viajeId)
    {
        var parameters = new DynamicParameters();
        parameters.Add(nameof(GetDetalleReservasResponse.ViajeId), viajeId, DbType.Int32);

        var result =
            await QuerySpAsync<GetDetalleReservasQueryResponse>(SpConstants.GetDetalleReservasByParams, parameters);
        var listData = result.ToList();
        if (listData.Count == 0)
            return new GetDetalleReservasResponse();

        return new GetDetalleReservasResponse
        {
            ViajeId = listData.First().ViajeId,
            Capacidad = listData.First().Capacidad,
            AsientosReservados = listData.Where(x => x.AsientosReservados != null).Select(x => x.AsientosReservados.GetValueOrDefault())
        };
    }

    public async Task<int> CreateDetalleReserva(CreateDetalleReservaRequest request)
    {
        return await ExecSpAsync(SpConstants.InsertDetalleReserva, request);
    }
}