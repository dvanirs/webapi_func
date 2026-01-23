using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi_Func.Application.DTOs;
using WebApi_Func.Domain.Interfaces;

namespace WebApi_Func.Application.Queries.GetUserById
{
    /// <summary>
    /// Manipulador responsável por obter um usuário pelo ID.
    /// </summary>
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Recupera os dados de um usuário pelo seu identificador.
        /// </summary>
        /// <param name="request">Query com o ID do usuário.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>DTO do usuário ou null se não encontrado.</returns>
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Nome = user.Nome,
                DataNascimento = user.DataNascimento,
                Endereco = user.Endereco,
                Telefone = user.Telefone,
                Cargo = user.Cargo,
                Ativo = user.Ativo,
                Matricula = user.Matricula
            };
        }
    }
}
