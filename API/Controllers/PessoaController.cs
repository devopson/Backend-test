using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Arguments.Pessoa;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _objPessoaService;

        public PessoaController(IPessoaService objPessoaService)
        {
            _objPessoaService = objPessoaService;
        }

        [Route("Listar")]
        [HttpGet]
        public List<Pessoa> Get()
        {
            return _objPessoaService.Listar();
        }

        [HttpGet]
        [Route("Listar/{id}")]
        public Pessoa Get(int id)
        {
            return _objPessoaService.ListarPorId(id);
        }

        [Route("Criar")]
        [HttpPost]
        public CriarPessoaResponse Post(CriarPessoaRequest criarPessoaRequest)
        {
            var response = _objPessoaService.Criar(criarPessoaRequest);
            return response;
        }

        [Route("Editar")]
        [HttpPut]
        public EditarPessoaResponse Edit(Pessoa pessoa)
        {
            return _objPessoaService.Editar(pessoa);
        }

        [Route("Deletar/{id}")]
        [HttpDelete]
        public ExcluirPessoaResponse Deletar(int id)
        {
            return _objPessoaService.Excluir(id);
        }
    }
}