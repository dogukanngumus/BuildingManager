using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BuildingManager.Core.Entities;

namespace BuildingManager.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity:class, IEntity, new()
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(List<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);

        TEntity Update(TEntity entity);
    }
}