using SRT.Domain.Models.Dtos.Paises;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class PaisService(IPaisesRepository paisesRepository) : IPaisService
{
    public async Task<GetPaisResponse?> GetPais(GetPaisRequest request)
    {
        if (request.PaisId is null && request.PaisName is null)
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del pais");

        var result = await paisesRepository.GetPaisByParams(request);
        return result is not null ? new GetPaisResponse(result) : null;
    }

    public async Task<IEnumerable<GetPaisResponse>> GetPaises()
    {
        var result = await paisesRepository.GetPaises();
        return result.Select(p => new GetPaisResponse(p));
    }

    public async Task<CreatePaisResponse> CreatePais(CreatePaisRequest request)
    {
        var result = await paisesRepository.CreatePais(request);
        return new CreatePaisResponse
        {
            PaisId = result,
            PaisName = request.PaisName
        };
    }

    public async Task<UpdatePaisResponse> UpdatePais(UpdatePaisRequest request)
    {
        await paisesRepository.UpdatePais(request);

        return new UpdatePaisResponse
        {
            PaisId = request.PaisId
        };
    }

    public async Task EliminarReactivarPais(int paisId, bool activo)
    {
        await paisesRepository.DeleteOrReactivePais(paisId, activo);
    }
}