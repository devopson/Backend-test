using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Arguments.Pessoa
{
    public class EditarPessoaResponse
    {
        public int Id { get; set; }

        public string Response { get; set; }

        public static explicit operator EditarPessoaResponse(Entities.Pessoa v)
        {
            return new EditarPessoaResponse()
            {
                Id = v.Id,
                Response = "Pessoa atualizada com sucesso!"
            };
        }
    }
}
