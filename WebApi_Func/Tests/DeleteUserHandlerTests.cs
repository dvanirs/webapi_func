using Moq;
using Xunit;
using WebApi_Func.Application.Commands.DeleteUser;
using WebApi_Func.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Func.Tests
{
    public class DeleteUserHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Delete_User_When_User_Exists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var command = new DeleteUserCommand { Id = 1 };

            mockRepo.Setup(r => r.ExistsAsync(1)).ReturnsAsync(true);
            mockRepo.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

            var handler = new DeleteUserHandler(mockRepo.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_User_Does_Not_Exist()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var command = new DeleteUserCommand { Id = 1 };

            mockRepo.Setup(r => r.ExistsAsync(1)).ReturnsAsync(false);

            var handler = new DeleteUserHandler(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
