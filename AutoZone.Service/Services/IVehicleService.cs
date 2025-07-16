using AutoZone.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoZone.Service.Services;

/// <summary>
/// Service interface for vehicle business logic operations.
/// Provides methods for managing vehicles with business rule validation and data transformation.
/// </summary>
public interface IVehicleService
{
    /// <summary>
    /// Retrieves all vehicles and converts them to DTOs for API consumption.
    /// </summary>
    /// <returns>A collection of vehicle DTOs representing all vehicles in the system.</returns>
    Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();

    /// <summary>
    /// Retrieves vehicles based on filter criteria and converts them to DTOs.
    /// </summary>
    /// <param name="filter">The filter criteria to apply when querying vehicles.</param>
    /// <returns>A collection of vehicle DTOs that match the filter criteria.</returns>
    Task<IEnumerable<VehicleDto>> GetFilteredVehiclesAsync(VehicleFilterDto filter);

    /// <summary>
    /// Retrieves a specific vehicle by its unique identifier and converts it to a DTO.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to retrieve.</param>
    /// <returns>The vehicle DTO with the specified ID, or null if not found.</returns>
    Task<VehicleDto?> GetVehicleByIdAsync(Guid id);

    /// <summary>
    /// Creates a new vehicle with business rule validation.
    /// </summary>
    /// <param name="createDto">The data transfer object containing vehicle creation information.</param>
    /// <returns>The created vehicle DTO with generated ID and other properties.</returns>
    /// <exception cref="ArgumentException">Thrown when the vehicle data is invalid according to business rules.</exception>
    Task<VehicleDto> CreateVehicleAsync(CreateVehicleDto createDto);

    /// <summary>
    /// Updates an existing vehicle with business rule validation.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to update.</param>
    /// <param name="updateDto">The data transfer object containing updated vehicle information.</param>
    /// <returns>The updated vehicle DTO.</returns>
    /// <exception cref="ArgumentException">Thrown when the vehicle data is invalid according to business rules.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the vehicle with the specified ID is not found.</exception>
    Task<VehicleDto> UpdateVehicleAsync(Guid id, UpdateVehicleDto updateDto);

    /// <summary>
    /// Deletes a vehicle from the system by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to delete.</param>
    /// <returns>True if the vehicle was successfully deleted; false if the vehicle was not found.</returns>
    Task<bool> DeleteVehicleAsync(Guid id);
} 