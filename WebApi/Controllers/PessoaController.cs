using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Arguments.Base;
using Domain.Arguments.Pessoa;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }

        [Route("Adicionar")]
        [HttpPost]
        public IActionResult Adicionar(PessoaRequest request)
        {
            try
            {
                var responseService = _pessoaService.CriarPessoa(request);

                PessoaResponseBase pessoaResponseBase = new PessoaResponseBase()
                {
                    result = responseService,
                    pessoaService = _pessoaService
                };

                return CreateResponse(pessoaResponseBase);
            }
            catch (Exception ex)
            {
                return Conflict($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("Atualizar")]
        [HttpPost]
        public IActionResult Atualizar(PessoaRequest request)
        {
            try
            {
                var responseService = _pessoaService.AtualizarPessoa(request);

                PessoaResponseBase pessoaResponseBase = new PessoaResponseBase()
                {
                    result = responseService,
                    pessoaService = _pessoaService
                };

                return CreateResponse(pessoaResponseBase);
            }
            catch (Exception ex)
            {
                return Conflict($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("Deletar")]
        [HttpPost]
        public IActionResult Deletar(PessoaRequest request)
        {
            try
            {
                var responseService = _pessoaService.DeletarPessoa(request);

                PessoaResponseBase pessoaResponseBase = new PessoaResponseBase()
                {
                    result = responseService,
                    pessoaService = _pessoaService
                };

                return CreateResponse(pessoaResponseBase);
            }
            catch (Exception ex)
            {
                return Conflict($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("Listar")]
        [HttpPost]
        public List<Pessoa> Listar()
        {
            return _pessoaService.ListarPessoa();
        }

        public IActionResult CreateResponse(PessoaResponseBase pessoaBase)
        {
            if (!pessoaBase.pessoaService.Notifications.Any())
            {
                try
                {
                    return Ok(pessoaBase.result);
                }
                catch (Exception ex)
                {
                    // Aqui devo logar o erro
                    return Conflict($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = pessoaBase.pessoaService.Notifications });
            }
        }
    }
}