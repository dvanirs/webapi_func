using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApi_Func.Application.DTOs;
using WebApi_Func.Domain.Interfaces;

namespace WebApi_Func.Application.Queries.GetAllUsers
{
    /// <summary>
    /// Manipulador responsável por obter a lista de usuários.
    /// </summary>
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Recupera a lista de usuários com base nos filtros da query.
        /// </summary>
        /// <param name="request">Filtros de consulta.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Lista de DTOs de usuários.</returns>
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync(request.Page, request.PageSize, request.SortOrder);

            // Manual mapping
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Nome = u.Nome,
                DataNascimento = u.DataNascimento,
                Endereco = u.Endereco,
                Telefone = u.Telefone,
                Cargo = u.Cargo,
                Ativo = u.Ativo,
                Matricula = u.Matricula
            });
        }
    }
}
