using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Pessoa
{
    public class CriarPessoaRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
