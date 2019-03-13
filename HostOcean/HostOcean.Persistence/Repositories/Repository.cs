using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistance;
using HostOcean.Domain.Entities;

namespace HostOcean.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> DbSet;

        public Repository(HostOceanDbContext dataBaseContext)
        {
            DbSet = dataBaseContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity) => DbSet.Add(entity).Entity;

        public virtual void AddRange(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);

        public void UpdateRange(IEnumerable<TEntity> entities) => DbSet.UpdateRange(entities);

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate);

        public virtual TEntity Get(string id) => DbSet.Find(id);

        public virtual TEntity Get(int id) => DbSet.Find(id);

        public virtual IEnumerable<TEntity> All => DbSet.ToList();

        public virtual TEntity Remove(TEntity entity) => DbSet.Remove(entity).Entity;

        public async Task<bool> IsExistByIdAsync(string id) => await DbSet.AnyAsync(x => x.Id == id);

        public virtual void RemoveRange(IEnumerable<TEntity> entities) => DbSet.RemoveRange(entities);

        public virtual void RemoveAll() => RemoveRange(All);

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => DbSet.SingleOrDefault(predicate);

        public virtual TEntity Update(TEntity entity) => DbSet.Update(entity).Entity;
    }
}