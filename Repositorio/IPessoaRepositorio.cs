using System.Collections.Generic;
using Backend_test.Models;

namespace Backend_test.Repositorio
{
    public interface IPessoaRepositorio
    {
        void Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        Pessoa Find(long id);
        void Remove(long id);
        void Update(Pessoa pessoa);

    }
}