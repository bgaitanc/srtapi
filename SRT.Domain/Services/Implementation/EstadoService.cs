using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class EstadoService : IEstadoService
{
    public Task<GetEstadoResponse> GetEstado(GetEstadoRequest request)
    {
        throw new NotImplementedException();
    }
}