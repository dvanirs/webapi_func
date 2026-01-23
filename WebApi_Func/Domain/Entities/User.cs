using System;

namespace WebApi_Func.Domain.Entities
{
    /// <summary>
    /// Representa um usuário do sistema.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Data de nascimento do usuário.
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Endereço completo do usuário.
        /// </summary>
        public string Endereco { get; set; } = string.Empty;

        /// <summary>
        /// Telefone de contato.
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Cargo ocupado pelo usuário na empresa.
        /// </summary>
        public string Cargo { get; set; } = string.Empty;

        /// <summary>
        /// Indica se o usuário está ativo no sistema.
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Número de matrícula do usuário.
        /// </summary>
        public string Matricula { get; set; } = string.Empty;
    }
}
