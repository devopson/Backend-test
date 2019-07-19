using System.Collections.Generic;
using Backend_test.Models;
using Backend_test.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Backend_test.Controllers
{
    [Route("api/[Controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRep;

        public PessoaController(IPessoaRepositorio pessoaRep)
        {
            _pessoaRep = pessoaRep;
        }
        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaRep.GetAll();
        }
        [HttpGet("{id}", Name="GetPessoa")]
        public IActionResult GetById(long id)
        {
            var pes = _pessoaRep.Find(id);
            if(pes==null)
                return NotFound();
            return new ObjectResult(pes);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Pessoa pessoa)
        {
            if(pessoa==null)
                return BadRequest();
            _pessoaRep.Add(pessoa);

            return CreatedAtRoute("GetPessoa", new {id=pessoa.Id}, pessoa);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pessoa pessoa)
        {
            if(pessoa==null || pessoa.Id != id)
                return BadRequest();
            var pes = _pessoaRep.Find(id);
            if(pes==null)
                return NotFound();
            pes.Nome = pessoa.Nome;
            pes.Telefone = pessoa.Telefone;
            pes.Endereco = pessoa.Endereco;
            pes.Email = pessoa.Email;
            pes.Cpf = pessoa.Cpf;

            _pessoaRep.Update(pes);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var pes = _pessoaRep.Find(id);
             if(pes==null)
                return NotFound();
            _pessoaRep.Remove(id);
            return new NoContentResult();
        }
    }
}