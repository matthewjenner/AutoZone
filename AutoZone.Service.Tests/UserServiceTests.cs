using AutoZone.Service.Services;
using AutoZone.Domain.Models;
using System.Threading.Tasks;
using AutoZone.Data.Repositories;
using Moq;
using Xunit;

namespace AutoZone.Service.Tests
{
    public class UserServiceTests
    {
        #region RegisterAsync Tests

        [Fact]
        public async Task RegisterAsync_Should_Add_User()
        {
            #region Arrange
            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            var service = new UserService(repoMock.Object);
            #endregion

            #region Act
            await service.RegisterAsync("testuser", "test@email.com", "pw", Role.Customer);
            #endregion

            #region Assert
            repoMock.Verify(r => r.AddAsync(It.Is<User>(u => u.Username == "testuser")), Times.Once);
            #endregion
        }

        #endregion

        #region GetUserByIdAsync Tests

        [Fact]
        public async Task GetUserByIdAsync_Returns_User()
        {
            #region Arrange
            var expected = new User { Id = System.Guid.NewGuid(), Username = "john" };
            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(r => r.GetByIdAsync(It.IsAny<System.Guid>())).ReturnsAsync(expected);
            var service = new UserService(repoMock.Object);
            #endregion

            #region Act
            User? result = await service.GetUserByIdAsync(expected.Id);
            #endregion

            #region Assert
            Assert.Equal(expected.Username, result.Username);
            #endregion
        }

        #endregion
    }
}
