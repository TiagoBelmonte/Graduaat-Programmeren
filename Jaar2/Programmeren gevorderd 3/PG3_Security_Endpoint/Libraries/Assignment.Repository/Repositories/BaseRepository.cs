using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignment.Repository.Repositories
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity> where TContext : DbContext where TEntity : class
    {
        #region Properties
        internal DbContext _dbContext;

        private DbSet<TEntity> _set;
        public DbSet<TEntity> Set { get { return _set; } set { _set = value; } }

        private static readonly char[] _separator = [','];
        #endregion

        #region Ctor
        public BaseRepository(TContext dbContext)
        {
            this._dbContext = dbContext;
            this.Set = dbContext.Set<TEntity>();
        }
        #endregion

        #region Methods

        public IQueryable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>()
                .Where(expression);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (_separator, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return [.. query];
            }
        }

        public virtual TEntity? GetByID(object id) => Set.Find(id);

        public virtual void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity? entityToDelete = Set.Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                Set.Attach(entityToDelete);
            }
            Set.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Set.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        #endregion
    }
}
