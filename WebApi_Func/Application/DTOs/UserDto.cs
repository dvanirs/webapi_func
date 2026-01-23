using System;

namespace WebApi_Func.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }
        public string Matricula { get; set; }
    }
}
