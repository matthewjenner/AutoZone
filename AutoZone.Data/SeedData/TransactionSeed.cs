using AutoZone.Domain.Models;
using System;
using System.Collections.Generic;

namespace AutoZone.Data.SeedData
{
    public static class TransactionSeed
    {
        public static List<Transaction> GetSeedData()
        {
            return
            [
                // User 1 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440001"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440001"),
                    Date = DateTime.Parse("2024-01-15"),
                    Amount = 45000m,
                    Type = "Purchase",
                    Description = "Ford Mustang purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440002"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440002"),
                    Date = DateTime.Parse("2024-02-20"),
                    Amount = 52000m,
                    Type = "Purchase",
                    Description = "Ford F-150 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440003"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440003"),
                    Date = DateTime.Parse("2024-03-10"),
                    Amount = 38000m,
                    Type = "Purchase",
                    Description = "Ford Explorer purchase"
                },

                // User 2 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440004"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440004"),
                    Date = DateTime.Parse("2024-01-25"),
                    Amount = 32000m,
                    Type = "Purchase",
                    Description = "Ford Escape purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440005"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440005"),
                    Date = DateTime.Parse("2024-02-15"),
                    Amount = 48000m,
                    Type = "Purchase",
                    Description = "Ford Bronco purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440006"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440006"),
                    Date = DateTime.Parse("2024-03-05"),
                    Amount = 42000m,
                    Type = "Purchase",
                    Description = "Chevrolet Camaro purchase"
                },

                // User 3 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440007"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440007"),
                    Date = DateTime.Parse("2024-01-30"),
                    Amount = 55000m,
                    Type = "Purchase",
                    Description = "Chevrolet Silverado purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440008"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440008"),
                    Date = DateTime.Parse("2024-02-25"),
                    Amount = 28000m,
                    Type = "Purchase",
                    Description = "Chevrolet Equinox purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440009"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440009"),
                    Date = DateTime.Parse("2024-03-15"),
                    Amount = 65000m,
                    Type = "Purchase",
                    Description = "Chevrolet Tahoe purchase"
                },

                // User 4 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440010"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440010"),
                    Date = DateTime.Parse("2024-01-10"),
                    Amount = 85000m,
                    Type = "Purchase",
                    Description = "Chevrolet Corvette purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440011"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440011"),
                    Date = DateTime.Parse("2024-02-05"),
                    Amount = 48000m,
                    Type = "Purchase",
                    Description = "Dodge Challenger purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440012"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440012"),
                    Date = DateTime.Parse("2024-03-20"),
                    Amount = 42000m,
                    Type = "Purchase",
                    Description = "Dodge Charger purchase"
                },

                // User 5 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440013"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440013"),
                    Date = DateTime.Parse("2024-01-20"),
                    Amount = 45000m,
                    Type = "Purchase",
                    Description = "Dodge Durango purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440014"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440014"),
                    Date = DateTime.Parse("2024-02-10"),
                    Amount = 28000m,
                    Type = "Purchase",
                    Description = "Dodge Grand Caravan purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440015"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440015"),
                    Date = DateTime.Parse("2024-03-25"),
                    Amount = 22000m,
                    Type = "Purchase",
                    Description = "Dodge Journey purchase"
                },

                // User 6 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440016"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440016"),
                    Date = DateTime.Parse("2024-01-05"),
                    Amount = 28000m,
                    Type = "Purchase",
                    Description = "Toyota Camry purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440017"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440017"),
                    Date = DateTime.Parse("2024-02-18"),
                    Amount = 32000m,
                    Type = "Purchase",
                    Description = "Toyota RAV4 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440018"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440018"),
                    Date = DateTime.Parse("2024-03-12"),
                    Amount = 45000m,
                    Type = "Purchase",
                    Description = "Toyota Highlander purchase"
                },

                // User 7 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440019"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440019"),
                    Date = DateTime.Parse("2024-01-12"),
                    Amount = 38000m,
                    Type = "Purchase",
                    Description = "Toyota Tacoma purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440020"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440020"),
                    Date = DateTime.Parse("2024-02-22"),
                    Amount = 25000m,
                    Type = "Purchase",
                    Description = "Toyota Corolla purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440021"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440021"),
                    Date = DateTime.Parse("2024-03-08"),
                    Amount = 25000m,
                    Type = "Purchase",
                    Description = "Honda Civic purchase"
                },

                // User 8 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440022"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440022"),
                    Date = DateTime.Parse("2024-01-18"),
                    Amount = 35000m,
                    Type = "Purchase",
                    Description = "Honda CR-V purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440023"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440023"),
                    Date = DateTime.Parse("2024-02-28"),
                    Amount = 42000m,
                    Type = "Purchase",
                    Description = "Honda Pilot purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440024"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440024"),
                    Date = DateTime.Parse("2024-03-14"),
                    Amount = 30000m,
                    Type = "Purchase",
                    Description = "Honda Accord purchase"
                },

                // User 9 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440025"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440025"),
                    Date = DateTime.Parse("2024-01-08"),
                    Amount = 38000m,
                    Type = "Purchase",
                    Description = "Honda Odyssey purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440026"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440026"),
                    Date = DateTime.Parse("2024-02-16"),
                    Amount = 52000m,
                    Type = "Purchase",
                    Description = "BMW 3 Series purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440027"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440027"),
                    Date = DateTime.Parse("2024-03-06"),
                    Amount = 48000m,
                    Type = "Purchase",
                    Description = "BMW X3 purchase"
                },

                // User 10 Transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440028"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440028"),
                    Date = DateTime.Parse("2024-01-14"),
                    Amount = 58000m,
                    Type = "Purchase",
                    Description = "BMW X5 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440029"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440029"),
                    Date = DateTime.Parse("2024-02-24"),
                    Amount = 65000m,
                    Type = "Purchase",
                    Description = "BMW 5 Series purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440030"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440030"),
                    Date = DateTime.Parse("2024-03-18"),
                    Amount = 85000m,
                    Type = "Purchase",
                    Description = "BMW M3 purchase"
                },

                // Additional transactions for variety
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440031"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440031"),
                    Date = DateTime.Parse("2024-04-01"),
                    Amount = 58000m,
                    Type = "Purchase",
                    Description = "Mercedes C-Class purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440032"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440032"),
                    Date = DateTime.Parse("2024-04-05"),
                    Amount = 65000m,
                    Type = "Purchase",
                    Description = "Mercedes E-Class purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440033"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440033"),
                    Date = DateTime.Parse("2024-04-10"),
                    Amount = 52000m,
                    Type = "Purchase",
                    Description = "Mercedes GLC purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440034"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440034"),
                    Date = DateTime.Parse("2024-04-15"),
                    Amount = 72000m,
                    Type = "Purchase",
                    Description = "Mercedes GLE purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440035"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440035"),
                    Date = DateTime.Parse("2024-04-20"),
                    Amount = 120000m,
                    Type = "Purchase",
                    Description = "Mercedes S-Class purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440036"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440036"),
                    Date = DateTime.Parse("2024-04-25"),
                    Amount = 49000m,
                    Type = "Purchase",
                    Description = "Audi A4 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440037"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440037"),
                    Date = DateTime.Parse("2024-05-01"),
                    Amount = 52000m,
                    Type = "Purchase",
                    Description = "Audi Q5 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440038"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440038"),
                    Date = DateTime.Parse("2024-05-05"),
                    Amount = 65000m,
                    Type = "Purchase",
                    Description = "Audi A6 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440039"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440039"),
                    Date = DateTime.Parse("2024-05-10"),
                    Amount = 75000m,
                    Type = "Purchase",
                    Description = "Audi Q7 purchase"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440040"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440040"),
                    Date = DateTime.Parse("2024-05-15"),
                    Amount = 85000m,
                    Type = "Purchase",
                    Description = "Audi RS5 purchase"
                },

                // Service transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440041"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440001"),
                    Date = DateTime.Parse("2024-05-20"),
                    Amount = 500m,
                    Type = "Service",
                    Description = "Oil change and maintenance"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440042"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440002"),
                    Date = DateTime.Parse("2024-05-22"),
                    Amount = 800m,
                    Type = "Service",
                    Description = "Brake replacement"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440043"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440003"),
                    Date = DateTime.Parse("2024-05-24"),
                    Amount = 1200m,
                    Type = "Service",
                    Description = "Tire replacement"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440044"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440004"),
                    Date = DateTime.Parse("2024-05-26"),
                    Amount = 300m,
                    Type = "Service",
                    Description = "Air filter replacement"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440045"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440005"),
                    Date = DateTime.Parse("2024-05-28"),
                    Amount = 600m,
                    Type = "Service",
                    Description = "Battery replacement"
                },

                // Refund transactions
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440046"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440006"),
                    Date = DateTime.Parse("2024-05-30"),
                    Amount = -42000m,
                    Type = "Refund",
                    Description = "Vehicle return and refund"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440047"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440007"),
                    Date = DateTime.Parse("2024-06-01"),
                    Amount = -55000m,
                    Type = "Refund",
                    Description = "Vehicle return and refund"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440048"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440008"),
                    Date = DateTime.Parse("2024-06-03"),
                    Amount = -28000m,
                    Type = "Refund",
                    Description = "Vehicle return and refund"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440049"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440009"),
                    Date = DateTime.Parse("2024-06-05"),
                    Amount = -65000m,
                    Type = "Refund",
                    Description = "Vehicle return and refund"
                },
                new()
                {
                    Id = Guid.Parse("770e8400-e29b-41d4-a716-446655440050"),
                    UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    VehicleId = Guid.Parse("660e8400-e29b-41d4-a716-446655440010"),
                    Date = DateTime.Parse("2024-06-07"),
                    Amount = -85000m,
                    Type = "Refund",
                    Description = "Vehicle return and refund"
                }
            ];
        }
    }
}
