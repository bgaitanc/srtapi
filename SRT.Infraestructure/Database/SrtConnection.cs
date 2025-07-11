using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SRT.Infraestructure.Database;

public class SrtConnection
{
    private readonly IConfiguration _configuration;

    public SrtConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection GetConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return new SqlConnection(connectionString);
    }
}