using Domain.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Persistencia.Repositories.Base
{
    public class BaseRespository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity
        where TId : struct
    {
        private readonly DbContext _dbContext;

        public BaseRespository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            var result = _dbContext.Set<TEntity>().Add(entity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public bool Exists(Func<TEntity, bool> where)
        {
            return _dbContext.Set<TEntity>().Any(where);
        }

        public TEntity Edit(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public TEntity GetById(TId id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
