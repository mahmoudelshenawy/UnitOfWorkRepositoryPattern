using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.EFCore.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IApplicationDbContext _context;

        public BaseRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
         public void DeleteRangeAsync(List<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>>? expression = null, string[] includes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);

            query = expression != null ? query.Where(expression) : query;
            return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string[] includes = null, int? take = null, int? skip = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);

            query = expression != null ? query.Where(expression) : query;
            query = orderBy != null ? orderBy(query) : query;

            if (skip != null)
                query = query.Skip((int)skip);

            if (take != null)
                query = query.Take((int)take);

            return await query.ToListAsync();
        }
        public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var query = _context.Set<TEntity>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            await _context.Set<TEntity>().ToListAsync(cancellationToken);


        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);
        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
                foreach (var item in includes)
                    query = query.Include(item);

            return await query.SingleOrDefaultAsync(expression);
        }
       
        public TEntity UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
