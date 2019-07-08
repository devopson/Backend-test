using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa, Guid>, IPessoaRepository
    {
        protected readonly BackendContext _backendContext;

        public PessoaRepository(BackendContext backendContext) : base(backendContext)
        {
            _backendContext = backendContext;
        }
    }
}
