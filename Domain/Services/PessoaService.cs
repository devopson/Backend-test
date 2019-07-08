using Domain.Arguments.Pessoa;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PessoaService : Notifiable, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public PessoaResponse CriarPessoa(PessoaRequest request)
        {
            if(request.Nome == null)
            {
                return new PessoaResponse()
                {
                    Response = "O Campo Nome é obrigatório"
                };
            }

            if (request.Email == null)
            {
                return new PessoaResponse()
                {
                    Response = "O Campo Email é obrigatório"
                };
            }

            if (_pessoaRepository.Existe(x => x.Email == request.Email))
            {
                return new PessoaResponse()
                {
                    Response = "Este email já foi cadastrado na base"
                };
            }

            Pessoa pessoa = new Pessoa()
            {
                Nome = request.Nome,
                Email = request.Email,
                CPF = request.CPF,
                Telefone = request.Telefone,
                Endereco = request.Endereco
            };

            pessoa = _pessoaRepository.Adicionar(pessoa);

            return (PessoaResponse)pessoa;
        }

        public PessoaResponse AtualizarPessoa(PessoaRequest request)
        {
            Pessoa pessoa = _pessoaRepository.ObterPorId(request.Id);

            if(pessoa == null)
            {
                return new PessoaResponse()
                {
                    Response = "Id não encontrado"
                };
            }

            pessoa.Nome = request.Nome;
            pessoa.Email = request.Email;
            pessoa.CPF = request.CPF;
            pessoa.Telefone = request.Telefone;
            pessoa.Endereco = request.Endereco;

            pessoa = _pessoaRepository.Editar(pessoa);

            return (PessoaResponse)pessoa;
        }

        public PessoaResponse DeletarPessoa(PessoaRequest request)
        {
            Pessoa pessoa = _pessoaRepository.ObterPorId(request.Id);

            if (pessoa == null)
            {
                return new PessoaResponse()
                {
                    Response = "Id não encontrado"
                };
            }

            var result = _pessoaRepository.Deletar(pessoa);

            return (PessoaResponse)pessoa;
        }

        public List<Pessoa> ListarPessoa()
        {
            return _pessoaRepository.Listar();
        }
    }
}
