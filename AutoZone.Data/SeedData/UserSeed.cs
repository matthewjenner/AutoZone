using AutoZone.Domain.Models;
using System;
using System.Collections.Generic;

namespace AutoZone.Data.SeedData
{
    public static class UserSeed
    {
        public static List<User> GetSeedData()
        {
            return
            [
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440001"),
                    Username = "admin",
                    Email = "admin@autozone.com",
                    PasswordHash = "hashed-admin-pw",
                    Role = Role.Admin
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440002"),
                    Username = "jdoe",
                    Email = "jdoe@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440003"),
                    Username = "sarah_smith",
                    Email = "sarah.smith@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440004"),
                    Username = "mike_johnson",
                    Email = "mike.johnson@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440005"),
                    Username = "lisa_wilson",
                    Email = "lisa.wilson@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440006"),
                    Username = "david_brown",
                    Email = "david.brown@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440007"),
                    Username = "emma_davis",
                    Email = "emma.davis@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440008"),
                    Username = "james_miller",
                    Email = "james.miller@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440009"),
                    Username = "olivia_garcia",
                    Email = "olivia.garcia@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                },
                new()
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440010"),
                    Username = "robert_rodriguez",
                    Email = "robert.rodriguez@email.com",
                    PasswordHash = "hashed-customer-pw",
                    Role = Role.Customer
                }
            ];
        }
    }
}
