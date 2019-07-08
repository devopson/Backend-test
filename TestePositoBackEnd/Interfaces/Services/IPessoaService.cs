using Domain.Arguments.Pessoa;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        CriarPessoaResponse Criar(CriarPessoaRequest criarPessoaRequest);

        ExcluirPessoaResponse Excluir(int id);

        EditarPessoaResponse Editar(Pessoa pessoa);

        List<Pessoa> Listar();

        Pessoa ListarPorId(int id);
    }
}
