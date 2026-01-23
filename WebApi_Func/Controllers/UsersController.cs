using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi_Func.Application.Commands.CreateUser;
using WebApi_Func.Application.Commands.DeleteUser;
using WebApi_Func.Application.Commands.UpdateUser;
using WebApi_Func.Application.Queries.GetAllUsers;
using WebApi_Func.Application.Queries.GetUserById;

namespace WebApi_Func.API.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento de usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna uma lista paginada de usuários.
        /// </summary>
        /// <param name="query">Filtros de paginação e ordenação.</param>
        /// <returns>Lista de usuários.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query)
        {
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        /// <summary>
        /// Obtém um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Dados do usuário.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="command">Dados do usuário.</param>
        /// <returns>Usuário criado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            try 
            {
                var user = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <param name="command">Novos dados do usuário.</param>
        /// <returns>Sem conteúdo.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest("ID comflict.");

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (System.Exception ex) // Simplifying for "User Not Found"
            {
                if (ex.Message.Contains("not found")) return NotFound();
                throw;
            }
        }

        /// <summary>
        /// Remove um usuário.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Sem conteúdo.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand { Id = id });
                return NoContent();
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("not found")) return NotFound();
                throw;
            }
        }
    }
}
