using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HostOcean.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool IsExist(dynamic id);
        TEntity Get(string id);
        TEntity Get(int id);
        IEnumerable<TEntity> All { get; }
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveAll();
    }
}