using Moq;
using Xunit;
using WebApi_Func.Application.Queries.GetUserById;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Func.Tests
{
    public class GetUserByIdHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_User_When_Found()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var query = new GetUserByIdQuery(1);
            var user = new User { Id = 1, Nome = "Teste Usuario" };

            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

            var handler = new GetUserByIdHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Usuario", result.Nome);
        }

        [Fact]
        public async Task Handle_Should_Return_Null_When_Not_Found()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var query = new GetUserByIdQuery(1);

            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((User?)null);

            var handler = new GetUserByIdHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
