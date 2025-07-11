using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Implementation;
using SRT.Domain.Services.Interface;
using SRT.Infraestructure.Database;
using SRT.Infraestructure.Repositories.Implementation;

namespace SRT.Utils.Extensions;

public static class BuilderServicesExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<SrtConnection>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    public static void RegisterAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}