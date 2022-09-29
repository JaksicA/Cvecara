using Cvecara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Repositories.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter,  List<Expression<Func<TEntity, object>>> includes = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
