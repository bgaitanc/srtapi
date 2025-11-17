using Microsoft.EntityFrameworkCore;
using SRT.Domain.Entities;
using SRT.Domain.Models.Dtos.Vehicles;
using SRT.Domain.Repositories.Interface;
using SRT.Infrastructure.Database;
using SRT.Infrastructure.Repositories.Implementation.Base;

namespace SRT.Infrastructure.Repositories.Implementation;

public class VehicleRepository(SrtDbContext context)
    : Repository<Vehicle>(context), IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> GetVehicles()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleByParams(GetVehicleRequest request)
    {
        var list = GetAll();

        if (request.VehicleId is not null)
            return await list.FirstOrDefaultAsync(v => v.Id == request.VehicleId);

        if (!string.IsNullOrWhiteSpace(request.RegistrationPlate))
            return await list.FirstOrDefaultAsync(v => v.RegistrationPlate == request.RegistrationPlate);

        return await list.FirstOrDefaultAsync(v => v.Model == request.Model);
    }
}