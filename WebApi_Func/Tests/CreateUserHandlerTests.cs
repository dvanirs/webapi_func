using Moq;
using Xunit;
using WebApi_Func.Application.Commands.CreateUser;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;

namespace WebApi_Func.Tests
{
    public class CreateUserHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_User_And_Return_Dto()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var command = new CreateUserCommand
            {
                Nome = "Teste",
                DataNascimento = DateTime.Now.AddYears(-20),
                Endereco = "Rua",
                Telefone = "11999999999",
                Cargo = "Desenvolvedor",
                Ativo = true,
                Matricula = "12345"
            };

            var userEntity = new User
            {
                Id = 1,
                Nome = command.Nome,
                DataNascimento = command.DataNascimento,
                Endereco = command.Endereco,
                Telefone = command.Telefone,
                Cargo = command.Cargo,
                Ativo = command.Ativo,
                Matricula = command.Matricula
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(userEntity);

            var handler = new CreateUserHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userEntity.Id, result.Id);
            Assert.Equal(userEntity.Nome, result.Nome);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
