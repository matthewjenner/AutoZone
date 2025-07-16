using System;
using System.Collections.Generic;

namespace AutoZone.Domain.Models;

/// <summary>
/// Represents a user in the AutoZone system.
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public ICollection<Vehicle>? Vehicles { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}

public enum Role
{
    Customer,
    Admin
}
