using SRT.Domain.Repositories.Interface;
using SRT.Domain.Services.Implementation;
using SRT.Domain.Services.Interface;
using SRT.Infrastructure.Repositories.Implementation;

namespace SRT.Dependency;

public static class DependencyConfigurations
{
    public static void ConfigureAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRolService, UserRolService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IDestinationService, DestinationService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IRouteService, RouteService>();
        services.AddScoped<ITravelService, TravelService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IReservationDetailService, ReservationDetailService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IDriverTripService, DriverTripService>();
    }

    public static void ConfigureAppRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRolRepository, UserRolRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<IDestinationRepository, DestinationRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<ITravelRepository, TravelRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReservationDetailRepository, ReservationDetailRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
    }
}