using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi_Func.Domain.Interfaces;

namespace WebApi_Func.Application.Commands.DeleteUser
{
    /// <summary>
    /// Manipulador responsável pela exclusão de um usuário.
    /// </summary>
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Processa a solicitação de exclusão de um usuário.
        /// </summary>
        /// <param name="request">Comando com o ID do usuário a ser excluído.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id);
            if (!exists)
            {
                throw new System.Exception($"Usuario com id {request.Id} não encontrado.");
            }

            await _repository.DeleteAsync(request.Id);
        }
    }
}
