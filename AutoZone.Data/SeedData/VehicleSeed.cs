using AutoZone.Domain.Models;
using System;
using System.Collections.Generic;

namespace AutoZone.Data.SeedData
{
    public static class VehicleSeed
    {
        public static List<Vehicle> GetSeedData()
        {
            return
            [
                // Ford Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440001"),
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2022,
                    Price = 45000m,
                    Mileage = 15000,
                    EngineSize = "5.0L",
                    Doors = 2,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Beautiful Ford Mustang in excellent condition with V8 power.",
                    Features = "V8 Engine,Leather Seats,Navigation,Bluetooth",
                    ImageUrls = "https://picsum.photos/800/600?random=1;https://picsum.photos/800/600?random=2;https://picsum.photos/800/600?random=3",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440002"),
                    Make = "Ford",
                    Model = "F-150",
                    Year = 2023,
                    Price = 52000m,
                    Mileage = 8000,
                    EngineSize = "3.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Powerful Ford F-150 pickup truck with towing capability.",
                    Features = "EcoBoost Engine,Towing Package,4x4,Backup Camera",
                    ImageUrls = "https://picsum.photos/800/600?random=4;https://picsum.photos/800/600?random=5;https://picsum.photos/800/600?random=6",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440003"),
                    Make = "Ford",
                    Model = "Explorer",
                    Year = 2021,
                    Price = 38000m,
                    Mileage = 25000,
                    EngineSize = "2.3L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Spacious Ford Explorer SUV perfect for families.",
                    Features = "Turbo Engine,Third Row Seating,AWD,Apple CarPlay",
                    ImageUrls = "https://picsum.photos/800/600?random=7;https://picsum.photos/800/600?random=8;https://picsum.photos/800/600?random=9",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440004"),
                    Make = "Ford",
                    Model = "Escape",
                    Year = 2022,
                    Price = 32000m,
                    Mileage = 18000,
                    EngineSize = "1.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Compact Ford Escape with great fuel efficiency.",
                    Features = "Hybrid Engine,Compact SUV,Bluetooth,Backup Sensors",
                    ImageUrls = "https://picsum.photos/800/600?random=10;https://picsum.photos/800/600?random=11;https://picsum.photos/800/600?random=12",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440005"),
                    Make = "Ford",
                    Model = "Bronco",
                    Year = 2023,
                    Price = 48000m,
                    Mileage = 5000,
                    EngineSize = "2.3L",
                    Doors = 2,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Iconic Ford Bronco with off-road capability.",
                    Features = "Off-road Package,Removable Top,4x4,Terrain Management",
                    ImageUrls = "https://picsum.photos/800/600?random=13;https://picsum.photos/800/600?random=14;https://picsum.photos/800/600?random=15",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Chevrolet Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440006"),
                    Make = "Chevrolet",
                    Model = "Camaro",
                    Year = 2021,
                    Price = 42000m,
                    Mileage = 22000,
                    EngineSize = "3.6L",
                    Doors = 2,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Sporty Chevrolet Camaro with low mileage and great performance.",
                    Features = "V6 Engine,Sport Package,Bluetooth,Leather Seats",
                    ImageUrls = "https://picsum.photos/800/600?random=16;https://picsum.photos/800/600?random=17;https://picsum.photos/800/600?random=18",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440007"),
                    Make = "Chevrolet",
                    Model = "Silverado",
                    Year = 2022,
                    Price = 55000m,
                    Mileage = 12000,
                    EngineSize = "5.3L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Powerful Chevrolet Silverado pickup truck.",
                    Features = "V8 Engine,Towing Package,4x4,Backup Camera",
                    ImageUrls = "https://picsum.photos/800/600?random=19;https://picsum.photos/800/600?random=20;https://picsum.photos/800/600?random=21",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440008"),
                    Make = "Chevrolet",
                    Model = "Equinox",
                    Year = 2021,
                    Price = 28000m,
                    Mileage = 30000,
                    EngineSize = "1.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Reliable Chevrolet Equinox compact SUV.",
                    Features = "Turbo Engine,Compact SUV,Bluetooth,Backup Sensors",
                    ImageUrls = "https://picsum.photos/800/600?random=22;https://picsum.photos/800/600?random=23;https://picsum.photos/800/600?random=24",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440009"),
                    Make = "Chevrolet",
                    Model = "Tahoe",
                    Year = 2023,
                    Price = 65000m,
                    Mileage = 8000,
                    EngineSize = "5.3L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Luxury Chevrolet Tahoe full-size SUV.",
                    Features = "V8 Engine,Third Row Seating,4x4,Leather Interior",
                    ImageUrls = "https://picsum.photos/800/600?random=25;https://picsum.photos/800/600?random=26;https://picsum.photos/800/600?random=27",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440010"),
                    Make = "Chevrolet",
                    Model = "Corvette",
                    Year = 2022,
                    Price = 85000m,
                    Mileage = 5000,
                    EngineSize = "6.2L",
                    Doors = 2,
                    InStock = false,
                    IsNewArrival = false,
                    Description = "High-performance Chevrolet Corvette sports car.",
                    Features = "V8 Engine,Mid-engine Design,Performance Package,Carbon Fiber",
                    ImageUrls = "https://picsum.photos/800/600?random=28;https://picsum.photos/800/600?random=29;https://picsum.photos/800/600?random=30",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Dodge Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440011"),
                    Make = "Dodge",
                    Model = "Challenger",
                    Year = 2023,
                    Price = 48000m,
                    Mileage = 8000,
                    EngineSize = "6.4L",
                    Doors = 2,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Powerful Dodge Challenger with premium features and Hemi V8.",
                    Features = "Hemi V8,Premium Audio,Heated Seats,Performance Package",
                    ImageUrls = "https://picsum.photos/800/600?random=31;https://picsum.photos/800/600?random=32;https://picsum.photos/800/600?random=33",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440012"),
                    Make = "Dodge",
                    Model = "Charger",
                    Year = 2022,
                    Price = 42000m,
                    Mileage = 15000,
                    EngineSize = "5.7L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Muscle car performance with sedan practicality.",
                    Features = "Hemi V8,Four Doors,Leather Seats,Performance Suspension",
                    ImageUrls = "https://picsum.photos/800/600?random=34;https://picsum.photos/800/600?random=35;https://picsum.photos/800/600?random=36",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440013"),
                    Make = "Dodge",
                    Model = "Durango",
                    Year = 2021,
                    Price = 45000m,
                    Mileage = 25000,
                    EngineSize = "3.6L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Spacious Dodge Durango SUV with three rows.",
                    Features = "V6 Engine,Third Row Seating,AWD,Towing Package",
                    ImageUrls = "https://picsum.photos/800/600?random=37;https://picsum.photos/800/600?random=38;https://picsum.photos/800/600?random=39",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440014"),
                    Make = "Dodge",
                    Model = "Grand Caravan",
                    Year = 2020,
                    Price = 28000m,
                    Mileage = 35000,
                    EngineSize = "3.6L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Practical Dodge Grand Caravan minivan.",
                    Features = "V6 Engine,Sliding Doors,Third Row Seating,Stow 'n Go",
                    ImageUrls = "https://picsum.photos/800/600?random=40;https://picsum.photos/800/600?random=41;https://picsum.photos/800/600?random=42",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440015"),
                    Make = "Dodge",
                    Model = "Journey",
                    Year = 2021,
                    Price = 22000m,
                    Mileage = 40000,
                    EngineSize = "2.4L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Affordable Dodge Journey crossover SUV.",
                    Features = "Four Cylinder Engine,Compact SUV,Third Row Seating,Bluetooth",
                    ImageUrls = "https://picsum.photos/800/600?random=43;https://picsum.photos/800/600?random=44;https://picsum.photos/800/600?random=45",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Toyota Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440016"),
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2021,
                    Price = 28000m,
                    Mileage = 35000,
                    EngineSize = "2.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Reliable Toyota Camry with great fuel efficiency and hybrid option.",
                    Features = "Hybrid Engine,Safety Package,Apple CarPlay,Toyota Safety Sense",
                    ImageUrls = "https://picsum.photos/800/600?random=46;https://picsum.photos/800/600?random=47;https://picsum.photos/800/600?random=48",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440017"),
                    Make = "Toyota",
                    Model = "RAV4",
                    Year = 2022,
                    Price = 32000m,
                    Mileage = 20000,
                    EngineSize = "2.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Popular Toyota RAV4 compact SUV with hybrid option.",
                    Features = "Hybrid Engine,AWD,Compact SUV,Safety Package",
                    ImageUrls = "https://picsum.photos/800/600?random=49;https://picsum.photos/800/600?random=50;https://picsum.photos/800/600?random=51",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440018"),
                    Make = "Toyota",
                    Model = "Highlander",
                    Year = 2023,
                    Price = 45000m,
                    Mileage = 10000,
                    EngineSize = "3.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Spacious Toyota Highlander three-row SUV.",
                    Features = "V6 Engine,Third Row Seating,AWD,Hybrid Option",
                    ImageUrls = "https://picsum.photos/800/600?random=52;https://picsum.photos/800/600?random=53;https://picsum.photos/800/600?random=54",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440019"),
                    Make = "Toyota",
                    Model = "Tacoma",
                    Year = 2022,
                    Price = 38000m,
                    Mileage = 18000,
                    EngineSize = "3.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Reliable Toyota Tacoma midsize pickup truck.",
                    Features = "V6 Engine,4x4,Towing Package,Off-road Capability",
                    ImageUrls = "https://picsum.photos/800/600?random=55;https://picsum.photos/800/600?random=56;https://picsum.photos/800/600?random=57",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440020"),
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2021,
                    Price = 25000m,
                    Mileage = 30000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Fuel-efficient Toyota Corolla compact sedan.",
                    Features = "Four Cylinder Engine,Compact Sedan,Safety Package,Hybrid Option",
                    ImageUrls = "https://picsum.photos/800/600?random=58;https://picsum.photos/800/600?random=59;https://picsum.photos/800/600?random=60",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Honda Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440021"),
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2022,
                    Price = 25000m,
                    Mileage = 18000,
                    EngineSize = "1.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Sporty Honda Civic with modern technology and turbo engine.",
                    Features = "Turbo Engine,Honda Sensing,Android Auto,Sport Package",
                    ImageUrls = "https://picsum.photos/800/600?random=61;https://picsum.photos/800/600?random=62;https://picsum.photos/800/600?random=63",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440022"),
                    Make = "Honda",
                    Model = "CR-V",
                    Year = 2023,
                    Price = 35000m,
                    Mileage = 8000,
                    EngineSize = "1.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Popular Honda CR-V compact SUV with turbo engine.",
                    Features = "Turbo Engine,Compact SUV,AWD,Honda Sensing",
                    ImageUrls = "https://picsum.photos/800/600?random=64;https://picsum.photos/800/600?random=65;https://picsum.photos/800/600?random=66",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440023"),
                    Make = "Honda",
                    Model = "Pilot",
                    Year = 2022,
                    Price = 42000m,
                    Mileage = 15000,
                    EngineSize = "3.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Spacious Honda Pilot three-row SUV.",
                    Features = "V6 Engine,Third Row Seating,AWD,Honda Sensing",
                    ImageUrls = "https://picsum.photos/800/600?random=67;https://picsum.photos/800/600?random=68;https://picsum.photos/800/600?random=69",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440024"),
                    Make = "Honda",
                    Model = "Accord",
                    Year = 2021,
                    Price = 30000m,
                    Mileage = 25000,
                    EngineSize = "1.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Reliable Honda Accord midsize sedan with turbo engine.",
                    Features = "Turbo Engine,Midsize Sedan,Honda Sensing,Apple CarPlay",
                    ImageUrls = "https://picsum.photos/800/600?random=70;https://picsum.photos/800/600?random=71;https://picsum.photos/800/600?random=72",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440025"),
                    Make = "Honda",
                    Model = "Odyssey",
                    Year = 2022,
                    Price = 38000m,
                    Mileage = 20000,
                    EngineSize = "3.5L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Family-friendly Honda Odyssey minivan.",
                    Features = "V6 Engine,Sliding Doors,Third Row Seating,Honda Sensing",
                    ImageUrls = "https://picsum.photos/800/600?random=73;https://picsum.photos/800/600?random=74;https://picsum.photos/800/600?random=75",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // BMW Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440026"),
                    Make = "BMW",
                    Model = "3 Series",
                    Year = 2021,
                    Price = 52000m,
                    Mileage = 12000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = false,
                    IsNewArrival = false,
                    Description = "Luxury BMW 3 Series with premium features and sporty handling.",
                    Features = "TwinPower Turbo,M Sport Package,iDrive 7.0,Leather Seats",
                    ImageUrls = "https://picsum.photos/800/600?random=76;https://picsum.photos/800/600?random=77;https://picsum.photos/800/600?random=78",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440027"),
                    Make = "BMW",
                    Model = "X3",
                    Year = 2022,
                    Price = 48000m,
                    Mileage = 18000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Luxury BMW X3 compact SUV with premium features.",
                    Features = "TwinPower Turbo,Compact SUV,xDrive AWD,iDrive 7.0",
                    ImageUrls = "https://picsum.photos/800/600?random=79;https://picsum.photos/800/600?random=80;https://picsum.photos/800/600?random=81",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440028"),
                    Make = "BMW",
                    Model = "X5",
                    Year = 2023,
                    Price = 65000m,
                    Mileage = 5000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Luxury BMW X5 midsize SUV with premium features.",
                    Features = "TwinPower Turbo,Midsize SUV,xDrive AWD,Third Row Seating",
                    ImageUrls = "https://picsum.photos/800/600?random=82;https://picsum.photos/800/600?random=83;https://picsum.photos/800/600?random=84",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440029"),
                    Make = "BMW",
                    Model = "5 Series",
                    Year = 2022,
                    Price = 58000m,
                    Mileage = 15000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Luxury BMW 5 Series midsize sedan with premium features.",
                    Features = "TwinPower Turbo,Midsize Sedan,xDrive AWD,iDrive 7.0",
                    ImageUrls = "https://picsum.photos/800/600?random=85;https://picsum.photos/800/600?random=86;https://picsum.photos/800/600?random=87",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440030"),
                    Make = "BMW",
                    Model = "M3",
                    Year = 2023,
                    Price = 85000m,
                    Mileage = 3000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "High-performance BMW M3 with M Sport package.",
                    Features = "TwinPower Turbo,M Sport Package,Performance Suspension,Carbon Fiber",
                    ImageUrls = "https://picsum.photos/800/600?random=88;https://picsum.photos/800/600?random=89;https://picsum.photos/800/600?random=90",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Mercedes Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440031"),
                    Make = "Mercedes",
                    Model = "C-Class",
                    Year = 2023,
                    Price = 58000m,
                    Mileage = 5000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Elegant Mercedes C-Class with luxury amenities and AMG styling.",
                    Features = "Turbo Engine,AMG Package,MBUX System,Leather Interior",
                    ImageUrls = "https://picsum.photos/800/600?random=91;https://picsum.photos/800/600?random=92;https://picsum.photos/800/600?random=93",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440032"),
                    Make = "Mercedes",
                    Model = "E-Class",
                    Year = 2022,
                    Price = 65000m,
                    Mileage = 12000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Luxury Mercedes E-Class midsize sedan with premium features.",
                    Features = "Turbo Engine,Luxury Sedan,MBUX System,Leather Interior",
                    ImageUrls = "https://picsum.photos/800/600?random=94;https://picsum.photos/800/600?random=95;https://picsum.photos/800/600?random=96",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440033"),
                    Make = "Mercedes",
                    Model = "GLC",
                    Year = 2023,
                    Price = 52000m,
                    Mileage = 8000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Luxury Mercedes GLC compact SUV with premium features.",
                    Features = "Turbo Engine,Compact SUV,4MATIC AWD,MBUX System",
                    ImageUrls = "https://picsum.photos/800/600?random=97;https://picsum.photos/800/600?random=98;https://picsum.photos/800/600?random=99",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440034"),
                    Make = "Mercedes",
                    Model = "GLE",
                    Year = 2022,
                    Price = 72000m,
                    Mileage = 15000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Luxury Mercedes GLE midsize SUV with premium features.",
                    Features = "TwinTurbo Engine,Midsize SUV,4MATIC AWD,Third Row Seating",
                    ImageUrls = "https://picsum.photos/800/600?random=100;https://picsum.photos/800/600?random=101;https://picsum.photos/800/600?random=102",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440035"),
                    Make = "Mercedes",
                    Model = "S-Class",
                    Year = 2023,
                    Price = 120000m,
                    Mileage = 2000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Ultra-luxury Mercedes S-Class flagship sedan.",
                    Features = "TwinTurbo Engine,Luxury Sedan,MBUX System,Executive Seating",
                    ImageUrls = "https://picsum.photos/800/600?random=103;https://picsum.photos/800/600?random=104;https://picsum.photos/800/600?random=105",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },

                // Audi Vehicles
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440036"),
                    Make = "Audi",
                    Model = "A4",
                    Year = 2022,
                    Price = 49000m,
                    Mileage = 15000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Sophisticated Audi A4 with quattro all-wheel drive and premium features.",
                    Features = "Quattro AWD,Virtual Cockpit,Bang & Olufsen Audio,Turbo Engine",
                    ImageUrls = "https://picsum.photos/800/600?random=106;https://picsum.photos/800/600?random=107;https://picsum.photos/800/600?random=108",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440037"),
                    Make = "Audi",
                    Model = "Q5",
                    Year = 2023,
                    Price = 52000m,
                    Mileage = 8000,
                    EngineSize = "2.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Luxury Audi Q5 compact SUV with quattro all-wheel drive.",
                    Features = "Quattro AWD,Compact SUV,Virtual Cockpit,Turbo Engine",
                    ImageUrls = "https://picsum.photos/800/600?random=109;https://picsum.photos/800/600?random=110;https://picsum.photos/800/600?random=111",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440038"),
                    Make = "Audi",
                    Model = "A6",
                    Year = 2022,
                    Price = 65000m,
                    Mileage = 12000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = false,
                    Description = "Luxury Audi A6 midsize sedan with quattro all-wheel drive.",
                    Features = "Quattro AWD,Midsize Sedan,Virtual Cockpit,Turbo Engine",
                    ImageUrls = "https://picsum.photos/800/600?random=112;https://picsum.photos/800/600?random=113;https://picsum.photos/800/600?random=114",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440039"),
                    Make = "Audi",
                    Model = "Q7",
                    Year = 2023,
                    Price = 75000m,
                    Mileage = 5000,
                    EngineSize = "3.0L",
                    Doors = 4,
                    InStock = true,
                    IsNewArrival = true,
                    Description = "Luxury Audi Q7 midsize SUV with quattro all-wheel drive.",
                    Features = "Quattro AWD,Midsize SUV,Virtual Cockpit,Third Row Seating",
                    ImageUrls = "https://picsum.photos/800/600?random=115;https://picsum.photos/800/600?random=116;https://picsum.photos/800/600?random=117",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                },
                new()
                {
                    Id = Guid.Parse("660e8400-e29b-41d4-a716-446655440040"),
                    Make = "Audi",
                    Model = "RS5",
                    Year = 2022,
                    Price = 85000m,
                    Mileage = 8000,
                    EngineSize = "2.9L",
                    Doors = 4,
                    InStock = false,
                    IsNewArrival = false,
                    Description = "High-performance Audi RS5 with quattro all-wheel drive.",
                    Features = "Quattro AWD,RS Performance Package,Turbo Engine,Carbon Fiber",
                    ImageUrls = "https://picsum.photos/800/600?random=118;https://picsum.photos/800/600?random=119;https://picsum.photos/800/600?random=120",
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001")
                }
            ];
        }
    }
}
