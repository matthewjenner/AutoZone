using System;

namespace AutoZone.Domain.Dtos;

public class VehicleDto
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
    public string[] Features { get; set; } = [];
    public string[] Images { get; set; } = [];
}

public class CreateVehicleDto
{
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
    public string[] Features { get; set; } = [];
    public string[] Images { get; set; } = [];
}

public class UpdateVehicleDto
{
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
    public string[] Features { get; set; } = [];
    public string[] Images { get; set; } = [];
} 