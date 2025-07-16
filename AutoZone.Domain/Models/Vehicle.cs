using System;
using System.Collections.Generic;

namespace AutoZone.Domain.Models;

/// <summary>
/// Represents a vehicle in the system.
/// </summary>
public class Vehicle
{
    public Guid Id { get; set; }
    public string Make { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string EngineSize { get; set; } = default!;
    public int Doors { get; set; }
    public bool InStock { get; set; }
    public bool IsNewArrival { get; set; }
    public string Description { get; set; } = default!;
    public string Features { get; set; } = default!;
    public string ImageUrls { get; set; } = default!;
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}
