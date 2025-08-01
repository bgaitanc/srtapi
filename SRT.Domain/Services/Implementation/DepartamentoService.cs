using SRT.Domain.Models.Dtos.Departamentos;
using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Interface;

namespace SRT.Domain.Services.Implementation;

public class DepartamentoService(IDepartamentosRepository departamentosRepository) : IDepartamentoService
{
    public async Task<GetDepartamentoResponse?> GetDepartamento(GetDepartamentoRequest request)
    {
        if (request.DepartamentoId is null && request.DepartamentoName is null)
            //TODO centralizar todos los mensajes, para poder reutilizar los mensajes genéricos
            throw new Exception("Para realizar la busqueda es necesario el id o el nombre del departamento");

        var result = await departamentosRepository.GetDepartamentoByParams(request);
        return result is not null ? new GetDepartamentoResponse(result) : null;
    }

    public async Task<IEnumerable<GetDepartamentoResponse>> GetDepartamentos(int? paisId)
    {
        var result = await departamentosRepository.GetDepartamentos(paisId);
        return result.Select(d => new GetDepartamentoResponse(d));
    }

    public async Task<CreateDepartamentoResponse> CreateDepartamento(CreateDepartamentoRequest request)
    {
        var result = await departamentosRepository.CreateDepartamento(request);
        return new CreateDepartamentoResponse
        {
            DepartamentoId = result,
            DepartamentoName = request.DepartamentoName,
            PaisId = request.PaisId
        };
    }

    public async Task<UpdateDepartamentoResponse> UpdateDepartamento(UpdateDepartamentoRequest request)
    {
        await departamentosRepository.UpdateDepartamento(request);

        return new UpdateDepartamentoResponse
        {
            DepartamentoId = request.DepartamentoId
        };
    }

    public async Task EliminarReactivarDepartamento(int departamentoId, bool activo)
    {
        await departamentosRepository.UpdateOrReactiveDepartamento(departamentoId, activo);
    }
}