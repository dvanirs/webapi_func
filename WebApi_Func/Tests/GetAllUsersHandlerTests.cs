using Moq;
using Xunit;
using WebApi_Func.Application.Queries.GetAllUsers;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Func.Tests
{
    public class GetAllUsersHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_List_Of_Users()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var query = new GetAllUsersQuery { Page = 1, PageSize = 10, SortOrder = "" };

            var users = new List<User>
            {
                new User { Id = 1, Nome = "Teste 1" },
                new User { Id = 2, Nome = "Teste 2" }
            };

            mockRepo.Setup(r => r.GetAllAsync(1, 10, "")).ReturnsAsync(users);

            var handler = new GetAllUsersHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            mockRepo.Verify(r => r.GetAllAsync(1, 10, ""), Times.Once);
        }
    }
}
