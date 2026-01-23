using Moq;
using Xunit;
using WebApi_Func.Application.Commands.UpdateUser;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace WebApi_Func.Tests
{
    public class UpdateUserHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Update_User_When_User_Exists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var command = new UpdateUserCommand
            {
                Id = 1,
                Nome = "Usuario Name",
                DataNascimento = DateTime.Now,
                Endereco = "New Address",
                Telefone = "999999999",
                Cargo = "Manager",
                Ativo = true,
                Matricula = "54321"
            };

            var existingUser = new User { Id = 1, Nome = "Old Name" };

            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingUser);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var handler = new UpdateUserHandler(mockRepo.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.UpdateAsync(It.Is<User>(u => u.Nome == "Usuario Name")), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_User_Does_Not_Exist()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var command = new UpdateUserCommand { Id = 1 };

            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((User?)null);

            var handler = new UpdateUserHandler(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
