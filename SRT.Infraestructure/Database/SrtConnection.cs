using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SRT.Infraestructure.Database;

public class SrtConnection(IConfiguration configuration)
{
    public SqlConnection GetConnection()
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return new SqlConnection(connectionString);
    }
}