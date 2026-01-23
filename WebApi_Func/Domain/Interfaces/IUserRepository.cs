using WebApi_Func.Domain.Entities;

namespace WebApi_Func.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários, definindo as operações de acesso a dados.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>O usuário encontrado ou null.</returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Obtém uma lista paginada de usuários.
        /// </summary>
        /// <param name="page">Número da página.</param>
        /// <param name="pageSize">Quantidade de itens por página.</param>
        /// <param name="sortOrder">Critério de ordenação.</param>
        /// <returns>Lista de usuários.</returns>
        Task<IEnumerable<User>> GetAllAsync(int page, int pageSize, string sortOrder);

        /// <summary>
        /// Adiciona um novo usuário ao banco de dados.
        /// </summary>
        /// <param name="user">Objeto usuário a ser criado.</param>
        /// <returns>O usuário criado com o ID gerado.</returns>
        Task<User> AddAsync(User user);

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="user">Objeto usuário com os dados atualizados.</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// Remove um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser removido.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Verifica se um usuário existe pelo ID.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <returns>True se existe, False caso contrário.</returns>
        Task<bool> ExistsAsync(int id);
    }
}
