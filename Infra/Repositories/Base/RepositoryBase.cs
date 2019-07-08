using Domain.Entities;
using Domain.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase
        where TId : struct
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Adicionar(TEntity entity)
        {
            var result = _dbContext.Set<TEntity>().Add(entity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public TEntity Editar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public List<Pessoa> Listar()
        {
            return _dbContext.Set<Pessoa>().ToList();
        }

        public bool Deletar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return true;
        }

        public bool Existe(Func<TEntity, bool> where)
        {
            return _dbContext.Set<TEntity>().Any(where);
        }

        public TEntity ObterPorId(TId id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
    }
}
