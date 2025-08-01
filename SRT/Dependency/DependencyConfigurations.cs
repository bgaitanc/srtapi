using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Implementation;
using SRT.Domain.Services.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation;

namespace SRT.Dependency;

public static class DependencyConfigurations
{
    public static void ConfigureAppServices(this IServiceCollection services)
    {
        services.AddScoped<SrtConnection>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IEstadoService, EstadoService>();
        services.AddScoped<IPaisService, PaisService>();
        services.AddScoped<IDepartamentoService, DepartamentoService>();
    }

    public static void ConfigureAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEstadosRepository, EstadosRepository>();
        services.AddScoped<IPaisesRepository, PaisesRepository>();
        services.AddScoped<IDepartamentosRepository, DepartamentosRepository>();
    }
}