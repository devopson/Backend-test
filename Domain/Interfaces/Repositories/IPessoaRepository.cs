using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IPessoaRepository: IRepositoryBase<Pessoa, Guid>
    {

    }
}
