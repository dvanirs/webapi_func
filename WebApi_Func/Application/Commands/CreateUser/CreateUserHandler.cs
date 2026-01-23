using MediatR;
using WebApi_Func.Application.DTOs;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;

namespace WebApi_Func.Application.Commands.CreateUser
{
    /// <summary>
    /// Manipulador responsável por processar o comando de criação de usuário.
    /// </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Processa a solicitação de criação de um novo usuário.
        /// </summary>
        /// <param name="request">Dados do comando de criação.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>DTO do usuário criado.</returns>
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Endereco = request.Endereco,
                Telefone = request.Telefone,
                Cargo = request.Cargo,
                Ativo = request.Ativo,
                Matricula = request.Matricula
            };

            var createdUser = await _repository.AddAsync(user);

            return new UserDto
            {
                Id = createdUser.Id,
                Nome = createdUser.Nome,
                DataNascimento = createdUser.DataNascimento,
                Endereco = createdUser.Endereco,
                Telefone = createdUser.Telefone,
                Cargo = createdUser.Cargo,
                Ativo = createdUser.Ativo,
                Matricula = createdUser.Matricula
            };
        }
    }
}
