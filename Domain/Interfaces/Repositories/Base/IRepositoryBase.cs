using Domain.Entities;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId> 
        where TEntity : class 
        where TId: struct
    {
        TEntity Adicionar(TEntity entity);

        TEntity Editar(TEntity entity);

        bool Deletar(TEntity entity);

        List<Pessoa> Listar();

        bool Existe(Func<TEntity, bool> where);

        TEntity ObterPorId(TId id);
    }
}
