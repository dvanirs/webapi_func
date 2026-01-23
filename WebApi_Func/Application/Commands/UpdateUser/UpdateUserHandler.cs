using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi_Func.Domain.Interfaces;
using System.Collections.Generic; // Added if needed, though unused here

namespace WebApi_Func.Application.Commands.UpdateUser
{
    /// <summary>
    /// Manipulador responsável por atualizar os dados de um usuário.
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Processa a atualização de um usuário existente.
        /// </summary>
        /// <param name="request">Comando com os novos dados.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                // In a real app, throw NotFoundException which middleware catches. 
                // For now, doing nothing or throwing simple exception.
                throw new System.Exception($"User with id {request.Id} not found.");
            }

            user.Nome = request.Nome;
            user.DataNascimento = request.DataNascimento;
            user.Endereco = request.Endereco;
            user.Telefone = request.Telefone;
            user.Cargo = request.Cargo;
            user.Ativo = request.Ativo;
            user.Matricula = request.Matricula;

            await _repository.UpdateAsync(user);
        }
    }
}
