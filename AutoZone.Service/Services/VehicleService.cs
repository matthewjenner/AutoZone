using AutoZone.Domain.Dtos;
using AutoZone.Data.Repositories;
using AutoZone.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoZone.Service.Services;

/// <summary>
/// Service implementation for vehicle business logic operations.
/// Provides vehicle management with business rule validation and data transformation between entities and DTOs.
/// </summary>
public class VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc/>
    public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
    {
        IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<VehicleDto>> GetFilteredVehiclesAsync(VehicleFilterDto filter)
    {
        IEnumerable<Vehicle> vehicles = await _vehicleRepository.GetFilteredAsync(filter);
        return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
    }

    /// <inheritdoc/>
    public async Task<VehicleDto?> GetVehicleByIdAsync(Guid id)
    {
        Vehicle? vehicle = await _vehicleRepository.GetByIdAsync(id);
        return vehicle != null ? _mapper.Map<VehicleDto>(vehicle) : null;
    }

    /// <inheritdoc/>
    public async Task<VehicleDto> CreateVehicleAsync(CreateVehicleDto createDto)
    {
        // Business logic validation
        ValidateVehicleData(createDto);

        Vehicle? vehicle = _mapper.Map<Vehicle>(createDto);
        vehicle.Id = Guid.NewGuid();

        Vehicle createdVehicle = await _vehicleRepository.CreateAsync(vehicle);
        return _mapper.Map<VehicleDto>(createdVehicle);
    }

    /// <inheritdoc/>
    public async Task<VehicleDto> UpdateVehicleAsync(Guid id, UpdateVehicleDto updateDto)
    {
        // Business logic validation
        ValidateVehicleData(updateDto);

        Vehicle? existingVehicle = await _vehicleRepository.GetByIdAsync(id);
        if (existingVehicle == null)
            throw new InvalidOperationException($"Vehicle with ID {id} not found.");

        // Update properties
        _mapper.Map(updateDto, existingVehicle);

        Vehicle updatedVehicle = await _vehicleRepository.UpdateAsync(existingVehicle);
        return _mapper.Map<VehicleDto>(updatedVehicle);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteVehicleAsync(Guid id)
    {
        return await _vehicleRepository.DeleteAsync(id);
    }

    /// <summary>
    /// Validates vehicle data according to business rules for creation operations.
    /// </summary>
    /// <param name="dto">The vehicle data to validate.</param>
    /// <exception cref="ArgumentException">Thrown when validation fails.</exception>
    private void ValidateVehicleData(CreateVehicleDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Make))
            throw new ArgumentException("Make is required.");

        if (string.IsNullOrWhiteSpace(dto.Model))
            throw new ArgumentException("Model is required.");

        if (dto.Year < 1900 || dto.Year > DateTime.Now.Year + 1)
            throw new ArgumentException("Year must be between 1900 and next year.");

        if (dto.Price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (dto.Mileage < 0)
            throw new ArgumentException("Mileage cannot be negative.");

        if (string.IsNullOrWhiteSpace(dto.EngineSize))
            throw new ArgumentException("Engine size is required.");

        if (dto.Doors < 2 || dto.Doors > 5)
            throw new ArgumentException("Doors must be between 2 and 5.");

        if (string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Description is required.");
    }

    /// <summary>
    /// Validates vehicle data according to business rules for update operations.
    /// </summary>
    /// <param name="dto">The vehicle data to validate.</param>
    /// <exception cref="ArgumentException">Thrown when validation fails.</exception>
    private void ValidateVehicleData(UpdateVehicleDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Make))
            throw new ArgumentException("Make is required.");

        if (string.IsNullOrWhiteSpace(dto.Model))
            throw new ArgumentException("Model is required.");

        if (dto.Year < 1900 || dto.Year > DateTime.Now.Year + 1)
            throw new ArgumentException("Year must be between 1900 and next year.");

        if (dto.Price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (dto.Mileage < 0)
            throw new ArgumentException("Mileage cannot be negative.");

        if (string.IsNullOrWhiteSpace(dto.EngineSize))
            throw new ArgumentException("Engine size is required.");

        if (dto.Doors < 2 || dto.Doors > 5)
            throw new ArgumentException("Doors must be between 2 and 5.");

        if (string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Description is required.");
    }
} 