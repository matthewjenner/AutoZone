using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoZone.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    IsNewArrival = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440001"), "admin@autozone.com", "hashed-admin-pw", 1, "admin" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440002"), "jdoe@email.com", "hashed-customer-pw", 0, "jdoe" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440003"), "sarah.smith@email.com", "hashed-customer-pw", 0, "sarah_smith" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440004"), "mike.johnson@email.com", "hashed-customer-pw", 0, "mike_johnson" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440005"), "lisa.wilson@email.com", "hashed-customer-pw", 0, "lisa_wilson" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440006"), "david.brown@email.com", "hashed-customer-pw", 0, "david_brown" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440007"), "emma.davis@email.com", "hashed-customer-pw", 0, "emma_davis" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440008"), "james.miller@email.com", "hashed-customer-pw", 0, "james_miller" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440009"), "olivia.garcia@email.com", "hashed-customer-pw", 0, "olivia_garcia" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440010"), "robert.rodriguez@email.com", "hashed-customer-pw", 0, "robert_rodriguez" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Doors", "EngineSize", "Features", "ImageUrls", "InStock", "IsNewArrival", "Make", "Mileage", "Model", "Price", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("660e8400-e29b-41d4-a716-446655440001"), "Beautiful Ford Mustang in excellent condition with V8 power.", 2, "5.0L", "V8 Engine,Leather Seats,Navigation,Bluetooth", "https://picsum.photos/800/600?random=1;https://picsum.photos/800/600?random=2;https://picsum.photos/800/600?random=3", true, false, "Ford", 15000, "Mustang", 45000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440002"), "Powerful Ford F-150 pickup truck with towing capability.", 4, "3.5L", "EcoBoost Engine,Towing Package,4x4,Backup Camera", "https://picsum.photos/800/600?random=4;https://picsum.photos/800/600?random=5;https://picsum.photos/800/600?random=6", true, true, "Ford", 8000, "F-150", 52000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440003"), "Spacious Ford Explorer SUV perfect for families.", 4, "2.3L", "Turbo Engine,Third Row Seating,AWD,Apple CarPlay", "https://picsum.photos/800/600?random=7;https://picsum.photos/800/600?random=8;https://picsum.photos/800/600?random=9", true, false, "Ford", 25000, "Explorer", 38000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440004"), "Compact Ford Escape with great fuel efficiency.", 4, "1.5L", "Hybrid Engine,Compact SUV,Bluetooth,Backup Sensors", "https://picsum.photos/800/600?random=10;https://picsum.photos/800/600?random=11;https://picsum.photos/800/600?random=12", true, false, "Ford", 18000, "Escape", 32000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440005"), "Iconic Ford Bronco with off-road capability.", 2, "2.3L", "Off-road Package,Removable Top,4x4,Terrain Management", "https://picsum.photos/800/600?random=13;https://picsum.photos/800/600?random=14;https://picsum.photos/800/600?random=15", true, true, "Ford", 5000, "Bronco", 48000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440006"), "Sporty Chevrolet Camaro with low mileage and great performance.", 2, "3.6L", "V6 Engine,Sport Package,Bluetooth,Leather Seats", "https://picsum.photos/800/600?random=16;https://picsum.photos/800/600?random=17;https://picsum.photos/800/600?random=18", true, true, "Chevrolet", 22000, "Camaro", 42000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440007"), "Powerful Chevrolet Silverado pickup truck.", 4, "5.3L", "V8 Engine,Towing Package,4x4,Backup Camera", "https://picsum.photos/800/600?random=19;https://picsum.photos/800/600?random=20;https://picsum.photos/800/600?random=21", true, false, "Chevrolet", 12000, "Silverado", 55000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440008"), "Reliable Chevrolet Equinox compact SUV.", 4, "1.5L", "Turbo Engine,Compact SUV,Bluetooth,Backup Sensors", "https://picsum.photos/800/600?random=22;https://picsum.photos/800/600?random=23;https://picsum.photos/800/600?random=24", true, false, "Chevrolet", 30000, "Equinox", 28000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440009"), "Luxury Chevrolet Tahoe full-size SUV.", 4, "5.3L", "V8 Engine,Third Row Seating,4x4,Leather Interior", "https://picsum.photos/800/600?random=25;https://picsum.photos/800/600?random=26;https://picsum.photos/800/600?random=27", true, true, "Chevrolet", 8000, "Tahoe", 65000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440010"), "High-performance Chevrolet Corvette sports car.", 2, "6.2L", "V8 Engine,Mid-engine Design,Performance Package,Carbon Fiber", "https://picsum.photos/800/600?random=28;https://picsum.photos/800/600?random=29;https://picsum.photos/800/600?random=30", false, false, "Chevrolet", 5000, "Corvette", 85000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440011"), "Powerful Dodge Challenger with premium features and Hemi V8.", 2, "6.4L", "Hemi V8,Premium Audio,Heated Seats,Performance Package", "https://picsum.photos/800/600?random=31;https://picsum.photos/800/600?random=32;https://picsum.photos/800/600?random=33", true, false, "Dodge", 8000, "Challenger", 48000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440012"), "Muscle car performance with sedan practicality.", 4, "5.7L", "Hemi V8,Four Doors,Leather Seats,Performance Suspension", "https://picsum.photos/800/600?random=34;https://picsum.photos/800/600?random=35;https://picsum.photos/800/600?random=36", true, false, "Dodge", 15000, "Charger", 42000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440013"), "Spacious Dodge Durango SUV with three rows.", 4, "3.6L", "V6 Engine,Third Row Seating,AWD,Towing Package", "https://picsum.photos/800/600?random=37;https://picsum.photos/800/600?random=38;https://picsum.photos/800/600?random=39", true, false, "Dodge", 25000, "Durango", 45000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440014"), "Practical Dodge Grand Caravan minivan.", 4, "3.6L", "V6 Engine,Sliding Doors,Third Row Seating,Stow 'n Go", "https://picsum.photos/800/600?random=40;https://picsum.photos/800/600?random=41;https://picsum.photos/800/600?random=42", true, false, "Dodge", 35000, "Grand Caravan", 28000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2020 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440015"), "Affordable Dodge Journey crossover SUV.", 4, "2.4L", "Four Cylinder Engine,Compact SUV,Third Row Seating,Bluetooth", "https://picsum.photos/800/600?random=43;https://picsum.photos/800/600?random=44;https://picsum.photos/800/600?random=45", true, false, "Dodge", 40000, "Journey", 22000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440016"), "Reliable Toyota Camry with great fuel efficiency and hybrid option.", 4, "2.5L", "Hybrid Engine,Safety Package,Apple CarPlay,Toyota Safety Sense", "https://picsum.photos/800/600?random=46;https://picsum.photos/800/600?random=47;https://picsum.photos/800/600?random=48", true, false, "Toyota", 35000, "Camry", 28000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440017"), "Popular Toyota RAV4 compact SUV with hybrid option.", 4, "2.5L", "Hybrid Engine,AWD,Compact SUV,Safety Package", "https://picsum.photos/800/600?random=49;https://picsum.photos/800/600?random=50;https://picsum.photos/800/600?random=51", true, false, "Toyota", 20000, "RAV4", 32000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440018"), "Spacious Toyota Highlander three-row SUV.", 4, "3.5L", "V6 Engine,Third Row Seating,AWD,Hybrid Option", "https://picsum.photos/800/600?random=52;https://picsum.photos/800/600?random=53;https://picsum.photos/800/600?random=54", true, true, "Toyota", 10000, "Highlander", 45000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440019"), "Reliable Toyota Tacoma midsize pickup truck.", 4, "3.5L", "V6 Engine,4x4,Towing Package,Off-road Capability", "https://picsum.photos/800/600?random=55;https://picsum.photos/800/600?random=56;https://picsum.photos/800/600?random=57", true, false, "Toyota", 18000, "Tacoma", 38000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440020"), "Fuel-efficient Toyota Corolla compact sedan.", 4, "2.0L", "Four Cylinder Engine,Compact Sedan,Safety Package,Hybrid Option", "https://picsum.photos/800/600?random=58;https://picsum.photos/800/600?random=59;https://picsum.photos/800/600?random=60", true, false, "Toyota", 30000, "Corolla", 25000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440021"), "Sporty Honda Civic with modern technology and turbo engine.", 4, "1.5L", "Turbo Engine,Honda Sensing,Android Auto,Sport Package", "https://picsum.photos/800/600?random=61;https://picsum.photos/800/600?random=62;https://picsum.photos/800/600?random=63", true, true, "Honda", 18000, "Civic", 25000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440022"), "Popular Honda CR-V compact SUV with turbo engine.", 4, "1.5L", "Turbo Engine,Compact SUV,AWD,Honda Sensing", "https://picsum.photos/800/600?random=64;https://picsum.photos/800/600?random=65;https://picsum.photos/800/600?random=66", true, true, "Honda", 8000, "CR-V", 35000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440023"), "Spacious Honda Pilot three-row SUV.", 4, "3.5L", "V6 Engine,Third Row Seating,AWD,Honda Sensing", "https://picsum.photos/800/600?random=67;https://picsum.photos/800/600?random=68;https://picsum.photos/800/600?random=69", true, false, "Honda", 15000, "Pilot", 42000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440024"), "Reliable Honda Accord midsize sedan with turbo engine.", 4, "1.5L", "Turbo Engine,Midsize Sedan,Honda Sensing,Apple CarPlay", "https://picsum.photos/800/600?random=70;https://picsum.photos/800/600?random=71;https://picsum.photos/800/600?random=72", true, false, "Honda", 25000, "Accord", 30000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440025"), "Family-friendly Honda Odyssey minivan.", 4, "3.5L", "V6 Engine,Sliding Doors,Third Row Seating,Honda Sensing", "https://picsum.photos/800/600?random=73;https://picsum.photos/800/600?random=74;https://picsum.photos/800/600?random=75", true, false, "Honda", 20000, "Odyssey", 38000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440026"), "Luxury BMW 3 Series with premium features and sporty handling.", 4, "2.0L", "TwinPower Turbo,M Sport Package,iDrive 7.0,Leather Seats", "https://picsum.photos/800/600?random=76;https://picsum.photos/800/600?random=77;https://picsum.photos/800/600?random=78", false, false, "BMW", 12000, "3 Series", 52000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2021 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440027"), "Luxury BMW X3 compact SUV with premium features.", 4, "2.0L", "TwinPower Turbo,Compact SUV,xDrive AWD,iDrive 7.0", "https://picsum.photos/800/600?random=79;https://picsum.photos/800/600?random=80;https://picsum.photos/800/600?random=81", true, false, "BMW", 18000, "X3", 48000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440028"), "Luxury BMW X5 midsize SUV with premium features.", 4, "3.0L", "TwinPower Turbo,Midsize SUV,xDrive AWD,Third Row Seating", "https://picsum.photos/800/600?random=82;https://picsum.photos/800/600?random=83;https://picsum.photos/800/600?random=84", true, true, "BMW", 5000, "X5", 65000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440029"), "Luxury BMW 5 Series midsize sedan with premium features.", 4, "2.0L", "TwinPower Turbo,Midsize Sedan,xDrive AWD,iDrive 7.0", "https://picsum.photos/800/600?random=85;https://picsum.photos/800/600?random=86;https://picsum.photos/800/600?random=87", true, false, "BMW", 15000, "5 Series", 58000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440030"), "High-performance BMW M3 with M Sport package.", 4, "3.0L", "TwinPower Turbo,M Sport Package,Performance Suspension,Carbon Fiber", "https://picsum.photos/800/600?random=88;https://picsum.photos/800/600?random=89;https://picsum.photos/800/600?random=90", true, true, "BMW", 3000, "M3", 85000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440031"), "Elegant Mercedes C-Class with luxury amenities and AMG styling.", 4, "2.0L", "Turbo Engine,AMG Package,MBUX System,Leather Interior", "https://picsum.photos/800/600?random=91;https://picsum.photos/800/600?random=92;https://picsum.photos/800/600?random=93", true, true, "Mercedes", 5000, "C-Class", 58000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440032"), "Luxury Mercedes E-Class midsize sedan with premium features.", 4, "2.0L", "Turbo Engine,Luxury Sedan,MBUX System,Leather Interior", "https://picsum.photos/800/600?random=94;https://picsum.photos/800/600?random=95;https://picsum.photos/800/600?random=96", true, false, "Mercedes", 12000, "E-Class", 65000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440033"), "Luxury Mercedes GLC compact SUV with premium features.", 4, "2.0L", "Turbo Engine,Compact SUV,4MATIC AWD,MBUX System", "https://picsum.photos/800/600?random=97;https://picsum.photos/800/600?random=98;https://picsum.photos/800/600?random=99", true, true, "Mercedes", 8000, "GLC", 52000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440034"), "Luxury Mercedes GLE midsize SUV with premium features.", 4, "3.0L", "TwinTurbo Engine,Midsize SUV,4MATIC AWD,Third Row Seating", "https://picsum.photos/800/600?random=100;https://picsum.photos/800/600?random=101;https://picsum.photos/800/600?random=102", true, false, "Mercedes", 15000, "GLE", 72000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440035"), "Ultra-luxury Mercedes S-Class flagship sedan.", 4, "3.0L", "TwinTurbo Engine,Luxury Sedan,MBUX System,Executive Seating", "https://picsum.photos/800/600?random=103;https://picsum.photos/800/600?random=104;https://picsum.photos/800/600?random=105", true, true, "Mercedes", 2000, "S-Class", 120000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440036"), "Sophisticated Audi A4 with quattro all-wheel drive and premium features.", 4, "2.0L", "Quattro AWD,Virtual Cockpit,Bang & Olufsen Audio,Turbo Engine", "https://picsum.photos/800/600?random=106;https://picsum.photos/800/600?random=107;https://picsum.photos/800/600?random=108", true, false, "Audi", 15000, "A4", 49000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440037"), "Luxury Audi Q5 compact SUV with quattro all-wheel drive.", 4, "2.0L", "Quattro AWD,Compact SUV,Virtual Cockpit,Turbo Engine", "https://picsum.photos/800/600?random=109;https://picsum.photos/800/600?random=110;https://picsum.photos/800/600?random=111", true, true, "Audi", 8000, "Q5", 52000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440038"), "Luxury Audi A6 midsize sedan with quattro all-wheel drive.", 4, "3.0L", "Quattro AWD,Midsize Sedan,Virtual Cockpit,Turbo Engine", "https://picsum.photos/800/600?random=112;https://picsum.photos/800/600?random=113;https://picsum.photos/800/600?random=114", true, false, "Audi", 12000, "A6", 65000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440039"), "Luxury Audi Q7 midsize SUV with quattro all-wheel drive.", 4, "3.0L", "Quattro AWD,Midsize SUV,Virtual Cockpit,Third Row Seating", "https://picsum.photos/800/600?random=115;https://picsum.photos/800/600?random=116;https://picsum.photos/800/600?random=117", true, true, "Audi", 5000, "Q7", 75000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2023 },
                    { new Guid("660e8400-e29b-41d4-a716-446655440040"), "High-performance Audi RS5 with quattro all-wheel drive.", 4, "2.9L", "Quattro AWD,RS Performance Package,Turbo Engine,Carbon Fiber", "https://picsum.photos/800/600?random=118;https://picsum.photos/800/600?random=119;https://picsum.photos/800/600?random=120", false, false, "Audi", 8000, "RS5", 85000m, new Guid("550e8400-e29b-41d4-a716-446655440001"), 2022 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "Description", "Type", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("770e8400-e29b-41d4-a716-446655440001"), 45000m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford Mustang purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("660e8400-e29b-41d4-a716-446655440001") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440002"), 52000m, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford F-150 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("660e8400-e29b-41d4-a716-446655440002") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440003"), 38000m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford Explorer purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("660e8400-e29b-41d4-a716-446655440003") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440004"), 32000m, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford Escape purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("660e8400-e29b-41d4-a716-446655440004") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440005"), 48000m, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford Bronco purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("660e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440006"), 42000m, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet Camaro purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("660e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440007"), 55000m, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet Silverado purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("660e8400-e29b-41d4-a716-446655440007") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440008"), 28000m, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet Equinox purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("660e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440009"), 65000m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet Tahoe purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("660e8400-e29b-41d4-a716-446655440009") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440010"), 85000m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet Corvette purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440004"), new Guid("660e8400-e29b-41d4-a716-446655440010") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440011"), 48000m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dodge Challenger purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440004"), new Guid("660e8400-e29b-41d4-a716-446655440011") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440012"), 42000m, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dodge Charger purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440004"), new Guid("660e8400-e29b-41d4-a716-446655440012") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440013"), 45000m, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dodge Durango purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440005"), new Guid("660e8400-e29b-41d4-a716-446655440013") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440014"), 28000m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dodge Grand Caravan purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440005"), new Guid("660e8400-e29b-41d4-a716-446655440014") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440015"), 22000m, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dodge Journey purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440005"), new Guid("660e8400-e29b-41d4-a716-446655440015") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440016"), 28000m, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota Camry purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440006"), new Guid("660e8400-e29b-41d4-a716-446655440016") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440017"), 32000m, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota RAV4 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440006"), new Guid("660e8400-e29b-41d4-a716-446655440017") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440018"), 45000m, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota Highlander purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440006"), new Guid("660e8400-e29b-41d4-a716-446655440018") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440019"), 38000m, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota Tacoma purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440007"), new Guid("660e8400-e29b-41d4-a716-446655440019") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440020"), 25000m, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota Corolla purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440007"), new Guid("660e8400-e29b-41d4-a716-446655440020") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440021"), 25000m, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda Civic purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440007"), new Guid("660e8400-e29b-41d4-a716-446655440021") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440022"), 35000m, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda CR-V purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440008"), new Guid("660e8400-e29b-41d4-a716-446655440022") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440023"), 42000m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda Pilot purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440008"), new Guid("660e8400-e29b-41d4-a716-446655440023") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440024"), 30000m, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda Accord purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440008"), new Guid("660e8400-e29b-41d4-a716-446655440024") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440025"), 38000m, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda Odyssey purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440009"), new Guid("660e8400-e29b-41d4-a716-446655440025") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440026"), 52000m, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW 3 Series purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440009"), new Guid("660e8400-e29b-41d4-a716-446655440026") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440027"), 48000m, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW X3 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440009"), new Guid("660e8400-e29b-41d4-a716-446655440027") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440028"), 58000m, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW X5 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440010"), new Guid("660e8400-e29b-41d4-a716-446655440028") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440029"), 65000m, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW 5 Series purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440010"), new Guid("660e8400-e29b-41d4-a716-446655440029") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440030"), 85000m, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMW M3 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440010"), new Guid("660e8400-e29b-41d4-a716-446655440030") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440031"), 58000m, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes C-Class purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("660e8400-e29b-41d4-a716-446655440031") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440032"), 65000m, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes E-Class purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("660e8400-e29b-41d4-a716-446655440032") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440033"), 52000m, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes GLC purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("660e8400-e29b-41d4-a716-446655440033") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440034"), 72000m, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes GLE purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440004"), new Guid("660e8400-e29b-41d4-a716-446655440034") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440035"), 120000m, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes S-Class purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440005"), new Guid("660e8400-e29b-41d4-a716-446655440035") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440036"), 49000m, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audi A4 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440006"), new Guid("660e8400-e29b-41d4-a716-446655440036") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440037"), 52000m, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audi Q5 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440007"), new Guid("660e8400-e29b-41d4-a716-446655440037") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440038"), 65000m, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audi A6 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440008"), new Guid("660e8400-e29b-41d4-a716-446655440038") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440039"), 75000m, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audi Q7 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440009"), new Guid("660e8400-e29b-41d4-a716-446655440039") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440040"), 85000m, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Audi RS5 purchase", "Purchase", new Guid("550e8400-e29b-41d4-a716-446655440010"), new Guid("660e8400-e29b-41d4-a716-446655440040") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440041"), 500m, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil change and maintenance", "Service", new Guid("550e8400-e29b-41d4-a716-446655440001"), new Guid("660e8400-e29b-41d4-a716-446655440001") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440042"), 800m, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brake replacement", "Service", new Guid("550e8400-e29b-41d4-a716-446655440002"), new Guid("660e8400-e29b-41d4-a716-446655440002") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440043"), 1200m, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tire replacement", "Service", new Guid("550e8400-e29b-41d4-a716-446655440003"), new Guid("660e8400-e29b-41d4-a716-446655440003") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440044"), 300m, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Air filter replacement", "Service", new Guid("550e8400-e29b-41d4-a716-446655440004"), new Guid("660e8400-e29b-41d4-a716-446655440004") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440045"), 600m, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battery replacement", "Service", new Guid("550e8400-e29b-41d4-a716-446655440005"), new Guid("660e8400-e29b-41d4-a716-446655440005") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440046"), -42000m, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vehicle return and refund", "Refund", new Guid("550e8400-e29b-41d4-a716-446655440006"), new Guid("660e8400-e29b-41d4-a716-446655440006") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440047"), -55000m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vehicle return and refund", "Refund", new Guid("550e8400-e29b-41d4-a716-446655440007"), new Guid("660e8400-e29b-41d4-a716-446655440007") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440048"), -28000m, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vehicle return and refund", "Refund", new Guid("550e8400-e29b-41d4-a716-446655440008"), new Guid("660e8400-e29b-41d4-a716-446655440008") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440049"), -65000m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vehicle return and refund", "Refund", new Guid("550e8400-e29b-41d4-a716-446655440009"), new Guid("660e8400-e29b-41d4-a716-446655440009") },
                    { new Guid("770e8400-e29b-41d4-a716-446655440050"), -85000m, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vehicle return and refund", "Refund", new Guid("550e8400-e29b-41d4-a716-446655440010"), new Guid("660e8400-e29b-41d4-a716-446655440010") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VehicleId",
                table: "Transactions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
