using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.NameTranslation;
using SRT.Domain.Entities;
using SRT.Domain.Entities.Base;
using SRT.Domain.Entities.Identity;

namespace SRT.Infrastructure.Database;

public class SrtDbContext(DbContextOptions<SrtDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Travel> Travels { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationDetail> ReservationDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.HasPostgresEnum<TravelStatus>(name: "travelstatus",
            nameTranslator: new NpgsqlNullNameTranslator());
        modelBuilder.HasPostgresEnum<ReservationStatus>(name: "reservationstatus",
            nameTranslator: new NpgsqlNullNameTranslator());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned())
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.SetNull;
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp without time zone");
        configurationBuilder.Properties<TimeSpan>().HaveColumnType("interval");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var trackedEntities = GetTrackedEntities();

        var now = DateTime.Now;
        foreach (var entityEntry in trackedEntities)
        {
            if (entityEntry.Entity is not BaseEntity entity) continue;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = now;
                Entry(entity).Property(x => x.CreatedAt).IsModified = true;
                Entry(entity).Property(x => x.UpdatedAt).IsModified = false;
                Entry(entity).Property(x => x.UpdatedBy).IsModified = false;
            }

            if (entityEntry.State != EntityState.Modified) continue;

            entity.UpdatedAt = now;
            Entry(entity).Property(x => x.UpdatedAt).IsModified = true;
            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private IEnumerable<EntityEntry> GetTrackedEntities()
    {
        var state = new List<EntityState>
        {
            EntityState.Added,
            EntityState.Modified
        };

        return ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && state.Any(s => e.State == s));
    }
}