using Domain.Arguments.Pessoa;
using Domain.Entities;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPessoaService : INotifiable
    {
        PessoaResponse CriarPessoa(PessoaRequest request);

        List<Pessoa> ListarPessoa();

        PessoaResponse AtualizarPessoa(PessoaRequest request);

        PessoaResponse DeletarPessoa(PessoaRequest request);
    }
}
