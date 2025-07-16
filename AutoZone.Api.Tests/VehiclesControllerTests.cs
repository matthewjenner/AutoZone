using AutoZone.Api.Controllers;
using AutoZone.Domain.Dtos;
using AutoZone.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace AutoZone.Api.Tests
{
    public class VehiclesControllerTests
    {
        private readonly Mock<IVehicleService> _mockVehicleService;
        private readonly VehiclesController _controller;

        public VehiclesControllerTests()
        {
            _mockVehicleService = new Mock<IVehicleService>();
            _controller = new VehiclesController(_mockVehicleService.Object);
        }

        #region GetVehicles Tests

        [Fact]
        public async Task GetVehicles_ReturnsOkResult_WithVehicles()
        {
            #region Arrange
            var vehicles = new List<VehicleDto>
            {
                new() { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000m },
                new() { Id = Guid.NewGuid(), Make = "Chevrolet", Model = "Camaro", Year = 2021, Price = 42000m }
            };
            _mockVehicleService.Setup(x => x.GetAllVehiclesAsync()).ReturnsAsync(vehicles);
            #endregion

            #region Act
            ActionResult<IEnumerable<VehicleDto>> result = await _controller.GetVehicles(null);
            #endregion

            #region Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<VehicleDto> returnedVehicles = Assert.IsAssignableFrom<IEnumerable<VehicleDto>>(okResult.Value);
            Assert.Equal(2, returnedVehicles.Count());
            #endregion
        }

        [Fact]
        public async Task GetVehicles_ReturnsOkResult_WithFilteredVehicles()
        {
            #region Arrange
            var filter = new VehicleFilterDto { Make = "Ford", PriceMax = 50000m };
            var vehicles = new List<VehicleDto>
            {
                new() { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000m }
            };
            _mockVehicleService.Setup(x => x.GetFilteredVehiclesAsync(filter)).ReturnsAsync(vehicles);
            #endregion

            #region Act
            ActionResult<IEnumerable<VehicleDto>> result = await _controller.GetVehicles(filter);
            #endregion

            #region Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<VehicleDto> returnedVehicles = Assert.IsAssignableFrom<IEnumerable<VehicleDto>>(okResult.Value);
            Assert.Single(returnedVehicles);
            #endregion
        }

        [Fact]
        public async Task GetVehicles_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            #region Arrange
            _mockVehicleService.Setup(x => x.GetAllVehiclesAsync()).ThrowsAsync(new Exception("Database error"));
            #endregion

            #region Act
            ActionResult<IEnumerable<VehicleDto>> result = await _controller.GetVehicles(null);
            #endregion

            #region Assert
            ObjectResult statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            #endregion
        }

        #endregion

        #region GetVehicle Tests

        [Fact]
        public async Task GetVehicle_ReturnsOkResult_WithVehicle()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            var vehicle = new VehicleDto { Id = vehicleId, Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000m };
            _mockVehicleService.Setup(x => x.GetVehicleByIdAsync(vehicleId)).ReturnsAsync(vehicle);
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.GetVehicle(vehicleId);
            #endregion

            #region Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            VehicleDto returnedVehicle = Assert.IsType<VehicleDto>(okResult.Value);
            Assert.Equal(vehicleId, returnedVehicle.Id);
            #endregion
        }

        [Fact]
        public async Task GetVehicle_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleService.Setup(x => x.GetVehicleByIdAsync(vehicleId)).ReturnsAsync((VehicleDto?)null);
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.GetVehicle(vehicleId);
            #endregion

            #region Assert
            NotFoundObjectResult notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.NotNull(notFoundResult.Value);
            PropertyInfo? messageProperty = notFoundResult.Value.GetType().GetProperty("message");
            Assert.NotNull(messageProperty);
            var message = messageProperty.GetValue(notFoundResult.Value) as string;
            Assert.Contains("Vehicle not found", message);
            #endregion
        }

        [Fact]
        public async Task GetVehicle_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleService.Setup(x => x.GetVehicleByIdAsync(vehicleId)).ThrowsAsync(new Exception("Database error"));
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.GetVehicle(vehicleId);
            #endregion

            #region Assert
            ObjectResult statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            #endregion
        }

        #endregion

        #region CreateVehicle Tests

        [Fact]
        public async Task CreateVehicle_ReturnsCreatedResult_WithVehicle()
        {
            #region Arrange
            var createDto = new CreateVehicleDto
            {
                Make = "Ford",
                Model = "Mustang",
                Year = 2022,
                Price = 45000m,
                Mileage = 15000,
                EngineSize = "5.0L",
                Doors = 2,
                Description = "Beautiful Ford Mustang",
                Features = new[] { "V8 Engine", "Leather Seats", "Navigation" }
            };
            var createdVehicle = new VehicleDto { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Price = 45000m };
            _mockVehicleService.Setup(x => x.CreateVehicleAsync(createDto)).ReturnsAsync(createdVehicle);
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.CreateVehicle(createDto);
            #endregion

            #region Assert
            CreatedAtActionResult createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            VehicleDto returnedVehicle = Assert.IsType<VehicleDto>(createdResult.Value);
            Assert.Equal("Ford", returnedVehicle.Make);
            #endregion
        }

        [Fact]
        public async Task CreateVehicle_ReturnsBadRequest_WhenDtoIsInvalid()
        {
            #region Arrange
            var createDto = new CreateVehicleDto
            {
                Make = "",
                Model = "",
                Year = 0,
                Price = -1000m
            };
            _controller.ModelState.AddModelError("Make", "Make is required");
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.CreateVehicle(createDto);
            #endregion

            #region Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
            #endregion
        }

        [Fact]
        public async Task CreateVehicle_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            #region Arrange
            var createDto = new CreateVehicleDto
            {
                Make = "Ford",
                Model = "Mustang",
                Year = 2022,
                Price = 45000m
            };
            _mockVehicleService.Setup(x => x.CreateVehicleAsync(createDto)).ThrowsAsync(new Exception("Database error"));
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.CreateVehicle(createDto);
            #endregion

            #region Assert
            ObjectResult statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            #endregion
        }

        #endregion

        #region UpdateVehicle Tests

        [Fact]
        public async Task UpdateVehicle_ReturnsOkResult_WithUpdatedVehicle()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            var updateDto = new UpdateVehicleDto
            {
                Make = "Ford",
                Model = "Mustang GT",
                Year = 2023,
                Price = 48000m
            };
            var updatedVehicle = new VehicleDto { Id = vehicleId, Make = "Ford", Model = "Mustang GT", Year = 2023, Price = 48000m };
            _mockVehicleService.Setup(x => x.UpdateVehicleAsync(vehicleId, updateDto)).ReturnsAsync(updatedVehicle);
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.UpdateVehicle(vehicleId, updateDto);
            #endregion

            #region Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            VehicleDto returnedVehicle = Assert.IsType<VehicleDto>(okResult.Value);
            Assert.Equal("Mustang GT", returnedVehicle.Model);
            #endregion
        }

        [Fact]
        public async Task UpdateVehicle_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            var updateDto = new UpdateVehicleDto { Make = "Ford", Model = "Mustang GT", Year = 2023, Price = 48000m };
            _mockVehicleService.Setup(x => x.UpdateVehicleAsync(vehicleId, updateDto))
                .ThrowsAsync(new InvalidOperationException("Vehicle not found"));
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.UpdateVehicle(vehicleId, updateDto);
            #endregion

            #region Assert
            NotFoundObjectResult notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.NotNull(notFoundResult.Value);
            PropertyInfo? messageProperty = notFoundResult.Value.GetType().GetProperty("message");
            Assert.NotNull(messageProperty);
            var message = messageProperty.GetValue(notFoundResult.Value) as string;
            Assert.Contains("Vehicle not found", message);
            #endregion
        }

        [Fact]
        public async Task UpdateVehicle_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            var updateDto = new UpdateVehicleDto { Make = "Ford", Model = "Mustang GT", Year = 2023, Price = 48000m };
            _mockVehicleService.Setup(x => x.UpdateVehicleAsync(vehicleId, updateDto))
                .ThrowsAsync(new Exception("Database error"));
            #endregion

            #region Act
            ActionResult<VehicleDto> result = await _controller.UpdateVehicle(vehicleId, updateDto);
            #endregion

            #region Assert
            ObjectResult statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            #endregion
        }

        #endregion

        #region DeleteVehicle Tests

        [Fact]
        public async Task DeleteVehicle_ReturnsNoContent_WhenVehicleExists()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleService.Setup(x => x.DeleteVehicleAsync(vehicleId)).ReturnsAsync(true);
            #endregion

            #region Act
            ActionResult result = await _controller.DeleteVehicle(vehicleId);
            #endregion

            #region Assert
            Assert.IsType<NoContentResult>(result);
            #endregion
        }

        [Fact]
        public async Task DeleteVehicle_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleService.Setup(x => x.DeleteVehicleAsync(vehicleId)).ReturnsAsync(false);
            #endregion

            #region Act
            ActionResult result = await _controller.DeleteVehicle(vehicleId);
            #endregion

            #region Assert
            NotFoundObjectResult notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.NotNull(notFoundResult.Value);
            PropertyInfo? messageProperty = notFoundResult.Value.GetType().GetProperty("message");
            Assert.NotNull(messageProperty);
            var message = messageProperty.GetValue(notFoundResult.Value) as string;
            Assert.Contains("Vehicle not found", message);
            #endregion
        }

        [Fact]
        public async Task DeleteVehicle_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            #region Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleService.Setup(x => x.DeleteVehicleAsync(vehicleId)).ThrowsAsync(new Exception("Database error"));
            #endregion

            #region Act
            ActionResult result = await _controller.DeleteVehicle(vehicleId);
            #endregion

            #region Assert
            ObjectResult statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            #endregion
        }

        #endregion
    }
} 