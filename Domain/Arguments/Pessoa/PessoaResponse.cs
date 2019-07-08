using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Arguments.Pessoa
{
    public class PessoaResponse
    {
        public Guid Id { get; set; }
        public string Response { get; set; }

        public static explicit operator PessoaResponse(Entities.Pessoa v)
        {
            return new PessoaResponse()
            {
                Id = v.Id,
                Response = "Operação realizada com sucesso"
            };

        }
    }
}
