using System;

namespace AutoZone.Domain.Models;

/// <summary>
/// Represents a transaction (purchase, service, etc.) in the system.
/// </summary>
public class Transaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } = default!;
    public decimal Amount { get; set; }
    public string? Description { get; set; }
}
