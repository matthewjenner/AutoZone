using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoZone.Api.Dtos;
using AutoZone.Service.Services;
using AutoZone.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoZone.Api.Controllers;

/// <summary>
/// Controller for user-related API endpoints.
/// Provides user registration and management functionality.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController(UserService service) : ControllerBase
{
    private readonly UserService _service = service;

    /// <summary>
    /// Registers a new user in the system.
    /// This endpoint is accessible without authentication.
    /// </summary>
    /// <param name="dto">The user registration data containing username, email, password, and role.</param>
    /// <returns>An OK result if registration is successful.</returns>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        await _service.RegisterAsync(dto.Username, dto.Email, dto.Password, dto.Role);
        return Ok();
    }

    /// <summary>
    /// Retrieves all users in the system.
    /// This endpoint requires Admin role authentication.
    /// </summary>
    /// <returns>A collection of user DTOs representing all users in the system.</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        IEnumerable<User> users = await _service.GetAllUsersAsync();
        return Ok(users.Select(u => new UserDto(u)));
    }
}
