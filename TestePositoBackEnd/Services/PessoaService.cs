using Domain.Arguments.Pessoa;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.VObjectsBase;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PessoaService : Notifiable, IPessoaService
    {
        private readonly IPessoaRepository _objPessoaRepository;

        /// <summary>
        /// Construtor do repositório de pessoa
        /// </summary>
        /// <param name="objPessoaRepository">objPessoaRepository</param>
        public PessoaService(IPessoaRepository objPessoaRepository)
        {
            _objPessoaRepository = objPessoaRepository;
        }

        /// <summary>
        /// Método para criar nova pessoa
        /// </summary>
        /// <param name="criarPessoaRequest">criarPessoaRequest</param>
        /// <returns>CriarPessoaResponse</returns>
        public CriarPessoaResponse Criar(CriarPessoaRequest criarPessoaRequest)
        {
            var pessoa = new Pessoa()
            {
                Nome = criarPessoaRequest.Nome,
                Email = criarPessoaRequest.Email,
                Cpf = criarPessoaRequest.Cpf,
                Telefone = criarPessoaRequest.Telefone,
                Endereco = criarPessoaRequest.Endereco
            };

            if (pessoa.Nome != null && VerificaDadosExistentes(pessoa.Nome))
            {
                return new CriarPessoaResponse()
                {
                    Id = 0,
                    Response = "Não é possível salvar uma pessoa com NOME já existente!"
                };
            }
            else if (pessoa.Email != null && VerificaDadosExistentes(pessoa.Email))
            {
                return new CriarPessoaResponse()
                {
                    Id = 0,
                    Response = "Não é possível salvar uma pessoa com E-MAIL já existente!"
                };
            }
            else if (pessoa.Cpf != null && VerificaDadosExistentes(pessoa.Cpf))
            {
                return new CriarPessoaResponse()
                {
                    Id = 0,
                    Response = "Não é possível salvar uma pessoa com CPF já existente!"
                };
            }

            _objPessoaRepository.Create(pessoa);

            return (CriarPessoaResponse)pessoa;
        }

        /// <summary>
        /// Método responsável por editar pessoa existente
        /// </summary>
        /// <param name="pessoa">pessoa</param>
        /// <returns>EditarPessoaResponse</returns>
        public EditarPessoaResponse Editar(Pessoa pessoa)
        {
            _objPessoaRepository.Edit(pessoa);

            return (EditarPessoaResponse)pessoa;
        }

        /// <summary>
        /// Método responsável pela exclusão da pessoa
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ExcluirPessoaResponse</returns>
        public ExcluirPessoaResponse Excluir(int id)
        {
            var pessoa = _objPessoaRepository.GetById(id);
            _objPessoaRepository.Remove(pessoa);

            return (ExcluirPessoaResponse)pessoa;
        }

        /// <summary>
        /// Método responsável por listar todas pessoas
        /// </summary>
        /// <returns>Lista de pessoas</returns>
        public List<Pessoa> Listar()
        {
            return _objPessoaRepository.GetAll();
        }

        /// <summary>
        /// Método responsável por buscar pessoa por id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Pessoa</returns>
        public Pessoa ListarPorId(int id)
        {
            return _objPessoaRepository.GetById(id);
        }

        /// <summary>
        /// Método privado para verificação de dados existente
        /// </summary>
        /// <param name="dados">dados</param>
        /// <returns>bool</returns>
        private bool VerificaDadosExistentes(string dados)
        {
            var result = false;
            var listPessoas = _objPessoaRepository.GetAll().Where(x => x.Nome.Equals(dados)|| x.Email.Equals(dados) || x.Cpf.Equals(dados));

            if (listPessoas.Count() > 0)
            {
                result = !result;
            }

            return result;
        }
    }
}
