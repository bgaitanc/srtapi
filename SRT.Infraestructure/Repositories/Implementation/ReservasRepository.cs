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
}