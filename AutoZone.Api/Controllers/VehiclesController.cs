using AutoZone.Domain.Dtos;
using AutoZone.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoZone.Api.Controllers;

/// <summary>
/// Controller for vehicle-related API endpoints.
/// Provides CRUD operations for vehicle management with filtering capabilities.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IVehicleService vehicleService) : ControllerBase
{
    /// <summary>
    /// Retrieves vehicles from the system.
    /// Supports optional filtering parameters to narrow down results.
    /// </summary>
    /// <param name="filter">Optional filter criteria to apply when retrieving vehicles.</param>
    /// <returns>A collection of vehicles matching the criteria, or all vehicles if no filter is provided.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles([FromQuery] VehicleFilterDto? filter)
    {
        try
        {
            IEnumerable<VehicleDto> vehicles = filter != null 
                ? await vehicleService.GetFilteredVehiclesAsync(filter)
                : await vehicleService.GetAllVehiclesAsync();
            
            return Ok(vehicles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving vehicles.", error = ex.Message });
        }
    }

    /// <summary>
    /// Retrieves a specific vehicle by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to retrieve.</param>
    /// <returns>The vehicle with the specified ID, or NotFound if the vehicle doesn't exist.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleDto>> GetVehicle(Guid id)
    {
        try
        {
            VehicleDto? vehicle = await vehicleService.GetVehicleByIdAsync(id);
            
            if (vehicle == null)
                return NotFound(new { message = "Vehicle not found." });

            return Ok(vehicle);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while retrieving the vehicle.", error = ex.Message });
        }
    }

    /// <summary>
    /// Creates a new vehicle in the system.
    /// </summary>
    /// <param name="createDto">The vehicle data for creating a new vehicle.</param>
    /// <returns>The created vehicle with generated ID, or BadRequest if validation fails.</returns>
    [HttpPost]
    public async Task<ActionResult<VehicleDto>> CreateVehicle([FromBody] CreateVehicleDto createDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VehicleDto vehicle = await vehicleService.CreateVehicleAsync(createDto);
            
            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the vehicle.", error = ex.Message });
        }
    }

    /// <summary>
    /// Updates an existing vehicle in the system.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to update.</param>
    /// <param name="updateDto">The updated vehicle data.</param>
    /// <returns>The updated vehicle, or NotFound if the vehicle doesn't exist.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<VehicleDto>> UpdateVehicle(Guid id, [FromBody] UpdateVehicleDto updateDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VehicleDto vehicle = await vehicleService.UpdateVehicleAsync(id, updateDto);
            
            return Ok(vehicle);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the vehicle.", error = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a vehicle from the system.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle to delete.</param>
    /// <returns>NoContent if successful, or NotFound if the vehicle doesn't exist.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        try
        {
            var deleted = await vehicleService.DeleteVehicleAsync(id);
            
            if (!deleted)
                return NotFound(new { message = "Vehicle not found." });

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while deleting the vehicle.", error = ex.Message });
        }
    }
} 
