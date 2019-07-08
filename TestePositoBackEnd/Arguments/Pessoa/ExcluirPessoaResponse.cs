using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Pessoa
{
    public class ExcluirPessoaResponse
    {
        public int Id { get; set; }

        public string Response { get; set; }

        public static explicit operator ExcluirPessoaResponse(Entities.Pessoa v)
        {
            return new ExcluirPessoaResponse()
            {
                Id = v.Id,
                Response = "Pessoa Excluída com sucesso!"
            };
        }
    }
}
