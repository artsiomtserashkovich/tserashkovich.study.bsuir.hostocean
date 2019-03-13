using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Persistance
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(string id);
        TEntity Get(int id);
        IEnumerable<TEntity> All { get; }
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<bool> IsExistByIdAsync(string id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveAll();
    }
}