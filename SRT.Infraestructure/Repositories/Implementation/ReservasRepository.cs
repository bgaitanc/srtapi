using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class ReservasRepository(SrtConnection srtConnection) : Repository<Reservas>(srtConnection), IReservasRepository
{
    public async Task<int> CreateReserva(CreateReservaRequest request)
    {
        var date = DateTime.Now;
        var dataToSave = new
        {
            request.ViajeId,
            request.ClienteId,
            request.FechaReserva,
            FechaCreacion = date,
            CreadorId = default(int?),
            EstadoId = 1 //Activo?
        };

        return await ExecSpAsync(SpConstants.InsertReserva, dataToSave);
    }

    public async Task<IEnumerable<GetReservasResponse>> GetReservaByUserId(int userId)
    {
        var result =
            await QuerySpAsync<GetReservasQueryResponse>(SpConstants.GetReservasByParams, new { UserId = userId });
        var listData = result.ToList();
        if (listData.Count == 0)
            return new List<GetReservasResponse>();

        return listData.GroupBy(x => new { x.ReservaId, x.ViajeId })
            .Select(g => new GetReservasResponse
            {
                ReservaId = g.Key.ReservaId,
                ViajeId = g.Key.ViajeId,
                FechaReserva = g.First().FechaReserva,
                Detalle = g.Select(x => x.NumeroAsiento).ToList()
            });
    }
}