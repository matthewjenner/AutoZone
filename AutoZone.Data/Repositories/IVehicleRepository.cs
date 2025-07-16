using AutoZone.Domain.Models;
using AutoZone.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoZone.Data.Repositories;

/// <summary>
/// Repository interface for vehicle data access operations.
/// Provides methods for CRUD operations and filtering of vehicle entities.
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// Retrieves all vehicles from the database.
    /// </summary>
    /// <returns>A collection of all vehicles in the database.</returns>
    Task<IEnumerable<Vehicle>> GetAllAsync();

    /// <summary>
    /// Retrieves vehicles based on specified filter criteria.
    /// </summary>
    /// <param name="filter">The filter criteria to apply when querying vehicles.</param>
    /// <returns>A collection of vehicles that match the filter criteria.</returns>
    Task<IEnumerable<Vehicle>> GetFilteredAsync(VehicleFilterDto filter);

    /// <summary>
    /// Retrieves a specific vehicle by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to retrieve.</param>
    /// <returns>The vehicle with the specified ID, or null if not found.</returns>
    Task<Vehicle?> GetByIdAsync(Guid id);

    /// <summary>
    /// Creates a new vehicle in the database.
    /// </summary>
    /// <param name="vehicle">The vehicle entity to create.</param>
    /// <returns>The created vehicle with updated properties (e.g., generated ID).</returns>
    Task<Vehicle> CreateAsync(Vehicle vehicle);

    /// <summary>
    /// Updates an existing vehicle in the database.
    /// </summary>
    /// <param name="vehicle">The vehicle entity with updated properties.</param>
    /// <returns>The updated vehicle entity.</returns>
    Task<Vehicle> UpdateAsync(Vehicle vehicle);

    /// <summary>
    /// Deletes a vehicle from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to delete.</param>
    /// <returns>True if the vehicle was successfully deleted; false if the vehicle was not found.</returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Checks if a vehicle exists in the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to check.</param>
    /// <returns>True if the vehicle exists; false otherwise.</returns>
    Task<bool> ExistsAsync(Guid id);
} 