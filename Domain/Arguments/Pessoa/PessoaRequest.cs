using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Pessoa
{
    public class PessoaRequest
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
