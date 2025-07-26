using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Estados;
using SRT.Domain.Repositories.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation.Base;

namespace SRT.Infraestructure.Repositories.Implementation;

public class EstadosRepository(SrtConnection srtConnection) : Repository<Estados>(srtConnection), IEstadosRepository
{
    public async Task<Estados?> GetEstadoById(int estadoId)
    {
        const string sql = "SELECT * FROM Estados WHERE EstadoId = @estadoId";
        return await GetFirstOrDefaultAsync(sql, new { estadoId });
    }

    public async Task<Estados?> GetEstadoByName(string estadoName)
    {
        const string sql = "SELECT * FROM Estados WHERE EstadoName = @estadoName";
        return await GetFirstOrDefaultAsync(sql, new { estadoName });
    }

    public async Task<RegisterEstadoResponse> RegisterEstado(RegisterEstadoRequest request)
    {
        const string sql = """
                           INSERT INTO Estados(Estado, FechaCreacion, Activo)
                           VALUES (@Estado, @FechaCreacion, @Activo);
                           SELECT SCOPE_IDENTITY();
                           """;

        var date = DateTime.Now;

        var dataToSave = new
        {
            Estado = request.EstadoName,
            FechaCreacion = date,
            Activo = true
        };

        var result = await ExecAsync(sql, dataToSave);

        return new RegisterEstadoResponse
        {
            EstadoId = result,
            EstadoName = request.EstadoName
        };
    }
}