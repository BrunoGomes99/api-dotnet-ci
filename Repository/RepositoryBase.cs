using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TesteCI.Repository.Context;

namespace TesteCI.Repository
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected RadioDbContext _dbContext;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(RadioDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }
    }
}
