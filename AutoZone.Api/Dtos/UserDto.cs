using System;
using AutoZone.Domain.Models;

namespace AutoZone.Api.Dtos;

/// <summary>
/// DTO for user data.
/// </summary>
public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public UserDto(User user)
    {
        Id = user.Id;
        Username = user.Username;
        Email = user.Email;
        Role = user.Role;
    }
}
