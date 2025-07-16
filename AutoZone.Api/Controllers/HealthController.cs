using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoZone.Api.Dtos;
using AutoZone.Service.Services;
using AutoZone.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;

namespace AutoZone.Api.Controllers;

/// <summary>
/// Controller for health check endpoints.
/// Provides system health monitoring functionality.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HealthController() : ControllerBase
{
    /// <summary>
    /// Performs a health check on the API service.
    /// This endpoint is accessible without authentication and returns the current UTC timestamp.
    /// </summary>
    /// <returns>An OK result with the current UTC timestamp indicating the service is healthy.</returns>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Health()
    {
        return Ok($"Healthy at {DateTime.UtcNow}");
    }
}
