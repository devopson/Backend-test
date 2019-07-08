using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Arguments.Pessoa
{
    public class CriarPessoaResponse
    {
        public int Id { get; set; }

        public string  Response { get; set; }

        public static explicit operator CriarPessoaResponse(Entities.Pessoa v)
        {
            return new CriarPessoaResponse()
            {
                Id = v.Id,
                Response = "Pessoa Criada com sucesso!"
            };
        }
    }
}
