using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Business.Managers
{
    internal abstract class BaseManager<TEntity, TRepository> : IBaseManager<TEntity> 
        where TEntity : class, IEntity
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public BaseManager(TRepository repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            return _repository.Get(filter, includes);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null)
        {
            return _repository.GetFirst(filter, includes);
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
