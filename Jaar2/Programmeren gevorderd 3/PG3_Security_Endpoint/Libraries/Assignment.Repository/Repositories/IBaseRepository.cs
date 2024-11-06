using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignment.Repository.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Set { get; set; }

        void Delete(object id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "");
        TEntity? GetByID(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}