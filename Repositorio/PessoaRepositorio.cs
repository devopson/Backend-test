using System.Collections.Generic;
using System.Linq;
using Backend_test.Models;

namespace Backend_test.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly BancoContext _db;
        public PessoaRepositorio(BancoContext ctx)
        {
            _db = ctx;
        }
        public void Add(Pessoa pessoa)
        {
            _db.Pessoas.Add(pessoa);
            _db.SaveChanges();
        }

        public Pessoa Find(long id)
        {
            return _db.Pessoas.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _db.Pessoas.ToList();
        }

        public void Remove(long id)
        {
            var pes = _db.Pessoas.First(u => u.Id == id);
            _db.Pessoas.Remove(pes);
            _db.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _db.Pessoas.Update(pessoa);
            _db.SaveChanges();
        }
    }
}