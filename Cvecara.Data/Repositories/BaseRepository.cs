using Cvecara.Data.Data;
using Cvecara.Data.Entities;
using Cvecara.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Repositories
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,  List<Expression<Func<TEntity, object>>> includes = null)
        {
            var query = _context.Set<TEntity>().AsQueryable().AsNoTracking();
            
            if(includes != null && includes.Any())
            {
                includes.ForEach(x => query = query.Include(x));
            }

            return query.Where(filter ?? (x => true)).AsEnumerable();
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null)
        {
            var query = _context.Set<TEntity>().AsQueryable().AsNoTracking();

            if (includes != null && includes.Any())
            {
                includes.ForEach(x => query = query.Include(x));
            }

            return query.First(filter);
        }

        public void Remove(int id)
        {
            _context.Set<TEntity>().Remove(GetFirst(e => e.Id == id));
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
