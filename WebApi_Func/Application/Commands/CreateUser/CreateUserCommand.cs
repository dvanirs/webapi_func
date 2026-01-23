using MediatR;
using WebApi_Func.Application.DTOs;
using System;

namespace WebApi_Func.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }
        public string Matricula { get; set; }
    }
}
