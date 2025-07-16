using AutoZone.Data.SeedData;
using AutoZone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoZone.Data;

/// <summary>
/// The Entity Framework Core database context for AutoZone.
/// Manages database connections and entity configurations for the AutoZone application.
/// </summary>
public class AutoZoneDbContext(DbContextOptions<AutoZoneDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets the DbSet for User entities.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Gets the DbSet for Vehicle entities.
    /// </summary>
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    /// <summary>
    /// Gets the DbSet for Transaction entities.
    /// </summary>
    public DbSet<Transaction> Transactions => Set<Transaction>();

    /// <summary>
    /// Configures the database model and applies entity configurations and seed data.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure the database model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutoZoneDbContext).Assembly);
        
        // Seed data
        modelBuilder.Entity<User>().HasData(UserSeed.GetSeedData());
        modelBuilder.Entity<Vehicle>().HasData(VehicleSeed.GetSeedData());
        modelBuilder.Entity<Transaction>().HasData(TransactionSeed.GetSeedData());
    }
}
