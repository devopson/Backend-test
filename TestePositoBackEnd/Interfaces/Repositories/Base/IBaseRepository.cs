using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity, TId> 
        where TEntity : class 
        where TId : struct
    {
        TEntity Create(TEntity entity);

        TEntity Edit(TEntity entity);

        List<TEntity> GetAll();

        TEntity GetById(TId id);

        void Remove(TEntity entity);

        bool Exists(Func<TEntity, bool> where);
    }
}
