using SRT.Domain.Models.Dtos.Reservas;
using SRT.Domain.Models.Dtos.Viajes;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class ReservasService(
    IReservasRepository reservasRepository,
    IDetalleReservasService detalleReservasService,
    IViajesRepository viajesRepository)
    : IReservasService
{
    public async Task<GetReservaInfoResponse> CreateReserva(CreateReservaRequest request)
    {
        var result = await reservasRepository.CreateReserva(request);

        var detailResult = new List<CreateDetalleReservaResponse>();

        request.Detalle.AsParallel().ForAll(async d =>
        {
            var req = new CreateDetalleReservaRequest
            {
                ReservaId = result,
                NumeroAsiento = d
            };
            var dResult = await detalleReservasService.CreateDetalleReserva(req);
            detailResult.Add(dResult);
        });

        var viaje = await viajesRepository.GetViajeById(request.ViajeId);

        return new GetReservaInfoResponse
        {
            ReservaId = result,
            ViajeId = request.ViajeId,
            FechaReserva = request.FechaReserva,
            Detalle = detailResult,
            Viaje = new GetViajeInfoResponse
            {
                Costo = viaje!.Costo,
                FechaHoraLlegada = viaje.FechaHoraLlegada,
                FechaHoraSalida = viaje.FechaHoraSalida
            },
            Ruta = viaje.Ruta,
            Total = viaje.Costo * request.Detalle.Count
        };
    }

    public async Task<IEnumerable<GetReservaInfoResponse>> GetDetalleReservasByUserId(int userId)
    {
        var reservas = await reservasRepository.GetReservaByUserId(userId);
        var listData = reservas.ToList();
        if (listData.Count == 0) return new List<GetReservaInfoResponse>();

        var viajes = await viajesRepository.GetViajes();

        return listData.Select(x =>
        {
            var viaje = viajes.First(v => v.ViajeId == x.ViajeId);

            return new GetReservaInfoResponse
            {
                ReservaId = x.ReservaId,
                ViajeId = x.ViajeId,
                FechaReserva = x.FechaReserva,
                Detalle = x.Detalle.Select(z => new CreateDetalleReservaResponse
                {
                    NumeroAsiento = z
                }),
                Viaje = new GetViajeInfoResponse
                {
                    Costo = viaje.Costo,
                    FechaHoraLlegada = viaje.FechaHoraLlegada,
                    FechaHoraSalida = viaje.FechaHoraSalida
                },
                Ruta = viaje.Ruta,
                Total = viaje.Costo * x.Detalle.Count
            };
        });
    }
}