using AutoZone.Domain.Dtos;
using AutoZone.Data.Repositories;
using AutoZone.Domain.Models;
using AutoZone.Service.Services;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AutoZone.Service.Tests;

public class VehicleServiceTests
{
    private readonly Mock<IVehicleRepository> _mockVehicleRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly VehicleService _vehicleService;

    public VehicleServiceTests()
    {
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        _mockMapper = new Mock<IMapper>();
        _vehicleService = new VehicleService(_mockVehicleRepository.Object, _mockMapper.Object);
    }

    #region GetAllVehiclesAsync Tests

    [Fact]
    public async Task GetAllVehiclesAsync_ReturnsMappedVehicles()
    {
        #region Arrange
        var vehicles = new List<Vehicle>
        {
            new() { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 },
            new() { Id = Guid.NewGuid(), Make = "Chevrolet", Model = "Camaro", Year = 2021, Price = 42000 }
        };

        var vehicleDtos = new List<VehicleDto>
        {
            new() { Id = vehicles[0].Id, Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 },
            new() { Id = vehicles[1].Id, Make = "Chevrolet", Model = "Camaro", Year = 2021, Price = 42000 }
        };

        _mockVehicleRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(vehicles);
        _mockMapper.Setup(x => x.Map<IEnumerable<VehicleDto>>(vehicles)).Returns(vehicleDtos);
        #endregion

        #region Act
        IEnumerable<VehicleDto> result = await _vehicleService.GetAllVehiclesAsync();
        #endregion

        #region Assert
        Assert.Equal(vehicleDtos, result);
        _mockVehicleRepository.Verify(x => x.GetAllAsync(), Times.Once);
        _mockMapper.Verify(x => x.Map<IEnumerable<VehicleDto>>(vehicles), Times.Once);
        #endregion
    }

    #endregion

    #region GetFilteredVehiclesAsync Tests

    [Fact]
    public async Task GetFilteredVehiclesAsync_ReturnsFilteredVehicles()
    {
        #region Arrange
        var filter = new VehicleFilterDto { Make = "Ford" };
        var vehicles = new List<Vehicle>
        {
            new() { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 }
        };

        var vehicleDtos = new List<VehicleDto>
        {
            new() { Id = vehicles[0].Id, Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 }
        };

        _mockVehicleRepository.Setup(x => x.GetFilteredAsync(filter)).ReturnsAsync(vehicles);
        _mockMapper.Setup(x => x.Map<IEnumerable<VehicleDto>>(vehicles)).Returns(vehicleDtos);
        #endregion

        #region Act
        IEnumerable<VehicleDto> result = await _vehicleService.GetFilteredVehiclesAsync(filter);
        #endregion

        #region Assert
        Assert.Equal(vehicleDtos, result);
        _mockVehicleRepository.Verify(x => x.GetFilteredAsync(filter), Times.Once);
        _mockMapper.Verify(x => x.Map<IEnumerable<VehicleDto>>(vehicles), Times.Once);
        #endregion
    }

    #endregion

    #region GetVehicleByIdAsync Tests

    [Fact]
    public async Task GetVehicleByIdAsync_WithValidId_ReturnsVehicle()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        var vehicle = new Vehicle { Id = vehicleId, Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 };
        var vehicleDto = new VehicleDto { Id = vehicleId, Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000 };

        _mockVehicleRepository.Setup(x => x.GetByIdAsync(vehicleId)).ReturnsAsync(vehicle);
        _mockMapper.Setup(x => x.Map<VehicleDto>(vehicle)).Returns(vehicleDto);
        #endregion

        #region Act
        VehicleDto? result = await _vehicleService.GetVehicleByIdAsync(vehicleId);
        #endregion

        #region Assert
        Assert.Equal(vehicleDto, result);
        _mockVehicleRepository.Verify(x => x.GetByIdAsync(vehicleId), Times.Once);
        _mockMapper.Verify(x => x.Map<VehicleDto>(vehicle), Times.Once);
        #endregion
    }

    [Fact]
    public async Task GetVehicleByIdAsync_WithInvalidId_ReturnsNull()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        _mockVehicleRepository.Setup(x => x.GetByIdAsync(vehicleId)).ReturnsAsync((Vehicle?)null);
        #endregion

        #region Act
        VehicleDto? result = await _vehicleService.GetVehicleByIdAsync(vehicleId);
        #endregion

        #region Assert
        Assert.Null(result);
        _mockVehicleRepository.Verify(x => x.GetByIdAsync(vehicleId), Times.Once);
        _mockMapper.Verify(x => x.Map<VehicleDto>(It.IsAny<Vehicle>()), Times.Never);
        #endregion
    }

    #endregion

    #region CreateVehicleAsync Tests

    [Fact]
    public async Task CreateVehicleAsync_WithValidData_ReturnsCreatedVehicle()
    {
        #region Arrange
        var createDto = new CreateVehicleDto
        {
            Make = "Ford",
            Model = "Mustang",
            Year = 2022,
            Price = 45000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang",
            Features = new[] { "V8 Engine", "Leather Seats" },
            Images = new[] { "image1.jpg", "image2.jpg" }
        };

        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Make = "Ford",
            Model = "Mustang",
            Year = 2022,
            Price = 45000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang",
            Features = "V8 Engine,Leather Seats",
            ImageUrls = "image1.jpg;image2.jpg"
        };

        var vehicleDto = new VehicleDto
        {
            Id = vehicle.Id,
            Make = "Ford",
            Model = "Mustang",
            Year = 2022,
            Price = 45000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang",
            Features = new[] { "V8 Engine", "Leather Seats" },
            Images = new[] { "image1.jpg", "image2.jpg" }
        };

        _mockMapper.Setup(x => x.Map<Vehicle>(createDto)).Returns(vehicle);
        _mockVehicleRepository.Setup(x => x.CreateAsync(vehicle)).ReturnsAsync(vehicle);
        _mockMapper.Setup(x => x.Map<VehicleDto>(vehicle)).Returns(vehicleDto);
        #endregion

        #region Act
        VehicleDto result = await _vehicleService.CreateVehicleAsync(createDto);
        #endregion

        #region Assert
        Assert.Equal(vehicleDto, result);
        _mockMapper.Verify(x => x.Map<Vehicle>(createDto), Times.Once);
        _mockVehicleRepository.Verify(x => x.CreateAsync(vehicle), Times.Once);
        _mockMapper.Verify(x => x.Map<VehicleDto>(vehicle), Times.Once);
        #endregion
    }

    [Fact]
    public async Task CreateVehicleAsync_WithInvalidData_ThrowsArgumentException()
    {
        #region Arrange
        var createDto = new CreateVehicleDto
        {
            Make = "", // Invalid: empty make
            Model = "Mustang",
            Year = 2022,
            Price = 45000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang",
            Features = new[] { "V8 Engine", "Leather Seats" },
            Images = new[] { "image1.jpg", "image2.jpg" }
        };
        #endregion

        #region Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _vehicleService.CreateVehicleAsync(createDto));
        _mockMapper.Verify(x => x.Map<Vehicle>(It.IsAny<CreateVehicleDto>()), Times.Never);
        _mockVehicleRepository.Verify(x => x.CreateAsync(It.IsAny<Vehicle>()), Times.Never);
        #endregion
    }

    #endregion

    #region UpdateVehicleAsync Tests

    [Fact]
    public async Task UpdateVehicleAsync_WithValidData_ReturnsUpdatedVehicle()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        var updateDto = new UpdateVehicleDto
        {
            Make = "Ford",
            Model = "Mustang GT",
            Year = 2022,
            Price = 48000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang GT",
            Features = new[] { "V8 Engine", "Leather Seats", "Navigation" },
            Images = new[] { "image1.jpg", "image2.jpg", "image3.jpg" }
        };

        var existingVehicle = new Vehicle
        {
            Id = vehicleId,
            Make = "Ford",
            Model = "Mustang",
            Year = 2022,
            Price = 45000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang",
            Features = "V8 Engine,Leather Seats",
            ImageUrls = "image1.jpg;image2.jpg"
        };

        var updatedVehicle = new Vehicle
        {
            Id = vehicleId,
            Make = "Ford",
            Model = "Mustang GT",
            Year = 2022,
            Price = 48000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang GT",
            Features = "V8 Engine,Leather Seats,Navigation",
            ImageUrls = "image1.jpg;image2.jpg;image3.jpg"
        };

        var vehicleDto = new VehicleDto
        {
            Id = vehicleId,
            Make = "Ford",
            Model = "Mustang GT",
            Year = 2022,
            Price = 48000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang GT",
            Features = new[] { "V8 Engine", "Leather Seats", "Navigation" },
            Images = new[] { "image1.jpg", "image2.jpg", "image3.jpg" }
        };

        _mockVehicleRepository.Setup(x => x.GetByIdAsync(vehicleId)).ReturnsAsync(existingVehicle);
        _mockMapper.Setup(x => x.Map(updateDto, existingVehicle)).Returns(existingVehicle); // Map modifies existingVehicle in place
        _mockVehicleRepository.Setup(x => x.UpdateAsync(existingVehicle)).ReturnsAsync(existingVehicle);
        _mockMapper.Setup(x => x.Map<VehicleDto>(existingVehicle)).Returns(vehicleDto);
        #endregion

        #region Act
        VehicleDto result = await _vehicleService.UpdateVehicleAsync(vehicleId, updateDto);
        #endregion

        #region Assert
        Assert.Equal(vehicleDto, result);
        _mockVehicleRepository.Verify(x => x.GetByIdAsync(vehicleId), Times.Once);
        _mockMapper.Verify(x => x.Map(updateDto, existingVehicle), Times.Once);
        _mockVehicleRepository.Verify(x => x.UpdateAsync(existingVehicle), Times.Once);
        _mockMapper.Verify(x => x.Map<VehicleDto>(existingVehicle), Times.Once);
        #endregion
    }

    [Fact]
    public async Task UpdateVehicleAsync_WithInvalidId_ThrowsInvalidOperationException()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        var updateDto = new UpdateVehicleDto
        {
            Make = "Ford",
            Model = "Mustang GT",
            Year = 2022,
            Price = 48000,
            Mileage = 15000,
            EngineSize = "5.0L",
            Doors = 2,
            InStock = true,
            IsNewArrival = false,
            Description = "Beautiful Ford Mustang GT",
            Features = new[] { "V8 Engine", "Leather Seats", "Navigation" },
            Images = new[] { "image1.jpg", "image2.jpg", "image3.jpg" }
        };

        _mockVehicleRepository.Setup(x => x.GetByIdAsync(vehicleId)).ReturnsAsync((Vehicle?)null);
        #endregion

        #region Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _vehicleService.UpdateVehicleAsync(vehicleId, updateDto));
        _mockVehicleRepository.Verify(x => x.GetByIdAsync(vehicleId), Times.Once);
        _mockMapper.Verify(x => x.Map(It.IsAny<UpdateVehicleDto>(), It.IsAny<Vehicle>()), Times.Never);
        _mockVehicleRepository.Verify(x => x.UpdateAsync(It.IsAny<Vehicle>()), Times.Never);
        #endregion
    }

    #endregion

    #region DeleteVehicleAsync Tests

    [Fact]
    public async Task DeleteVehicleAsync_WithValidId_ReturnsTrue()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        _mockVehicleRepository.Setup(x => x.DeleteAsync(vehicleId)).ReturnsAsync(true);
        #endregion

        #region Act
        var result = await _vehicleService.DeleteVehicleAsync(vehicleId);
        #endregion

        #region Assert
        Assert.True(result);
        _mockVehicleRepository.Verify(x => x.DeleteAsync(vehicleId), Times.Once);
        #endregion
    }

    [Fact]
    public async Task DeleteVehicleAsync_WithInvalidId_ReturnsFalse()
    {
        #region Arrange
        var vehicleId = Guid.NewGuid();
        _mockVehicleRepository.Setup(x => x.DeleteAsync(vehicleId)).ReturnsAsync(false);
        #endregion

        #region Act
        var result = await _vehicleService.DeleteVehicleAsync(vehicleId);
        #endregion

        #region Assert
        Assert.False(result);
        _mockVehicleRepository.Verify(x => x.DeleteAsync(vehicleId), Times.Once);
        #endregion
    }

    #endregion
} 