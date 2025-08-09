using SRT.Domain.Models.Dtos.Departamentos;

namespace SRT.Domain.Services.Interface;

public interface IDepartamentoService
{
    Task<GetDepartamentoResponse?> GetDepartamento(GetDepartamentoRequest request);
    Task<IEnumerable<GetDepartamentoResponse>> GetDepartamentos(int? paisId);
    Task<CreateDepartamentoResponse> CreateDepartamento(CreateDepartamentoRequest request);
    Task<UpdateDepartamentoResponse> UpdateDepartamento(UpdateDepartamentoRequest request);
    Task EliminarReactivarDepartamento(int departamentoId, bool activo);
}