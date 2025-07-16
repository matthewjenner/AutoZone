using AutoZone.Domain.Models;
using AutoZone.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoZone.Data.Repositories;

/// <summary>
/// Repository implementation for vehicle data access operations using Entity Framework Core.
/// Provides CRUD operations and filtering capabilities for vehicle entities.
/// </summary>
public class VehicleRepository : IVehicleRepository
{
    private readonly AutoZoneDbContext _context;

    /// <summary>
    /// Initializes a new instance of the VehicleRepository class.
    /// </summary>
    /// <param name="context">The database context for vehicle operations.</param>
    public VehicleRepository(AutoZoneDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Vehicle>> GetFilteredAsync(VehicleFilterDto filter)
    {
        IQueryable<Vehicle> query = _context.Vehicles.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Make))
            query = query.Where(v => v.Make == filter.Make);

        if (!string.IsNullOrEmpty(filter.Model))
            query = query.Where(v => v.Model == filter.Model);

        if (filter.YearMin.HasValue)
            query = query.Where(v => v.Year >= filter.YearMin.Value);

        if (filter.YearMax.HasValue)
            query = query.Where(v => v.Year <= filter.YearMax.Value);

        if (filter.PriceMin.HasValue)
            query = query.Where(v => v.Price >= filter.PriceMin.Value);

        if (filter.PriceMax.HasValue)
            query = query.Where(v => v.Price <= filter.PriceMax.Value);

        if (!string.IsNullOrEmpty(filter.EngineSize))
            query = query.Where(v => v.EngineSize == filter.EngineSize);

        if (filter.Doors.HasValue)
            query = query.Where(v => v.Doors == filter.Doors.Value);

        if (filter.InStockOnly.HasValue && filter.InStockOnly.Value)
            query = query.Where(v => v.InStock);

        if (filter.NewArrivals.HasValue && filter.NewArrivals.Value)
            query = query.Where(v => v.IsNewArrival);

        if (filter.Features != null && filter.Features.Any())
        {
            foreach (var feature in filter.Features)
            {
                query = query.Where(v => v.Features.Contains(feature));
            }
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    /// <inheritdoc/>
    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    /// <inheritdoc/>
    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id)
    {
        Vehicle? vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
            return false;

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Vehicles.AnyAsync(v => v.Id == id);
    }
} 
