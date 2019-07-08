using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Persistencia.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Persistencia.Repositories
{
    public class PessoaRepository : BaseRespository<Pessoa, int>, IPessoaRepository
    {
        protected readonly ContextDB _context;

        public PessoaRepository(ContextDB context) : base(context)
        {
            _context = context;
        }
    }
}
