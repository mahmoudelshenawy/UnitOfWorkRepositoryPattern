using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkRepositoryPattern.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>>? expression = null, string[] includes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string[] includes = null, int? take = null, int? skip = null);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);

        TEntity UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        void DeleteRangeAsync(List<TEntity> entities);


    }
}
