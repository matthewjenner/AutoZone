using AutoZone.Domain.Models;

namespace AutoZone.Api.Dtos;

/// <summary>
/// DTO for user registration.
/// </summary>
public class RegisterUserDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public Role Role { get; set; }
}
