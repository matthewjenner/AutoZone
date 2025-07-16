namespace AutoZone.Domain.Dtos;

public class VehicleFilterDto
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? YearMin { get; set; }
    public int? YearMax { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public string? EngineSize { get; set; }
    public int? Doors { get; set; }
    public bool? InStockOnly { get; set; }
    public bool? NewArrivals { get; set; }
    public string[]? Features { get; set; }
} 