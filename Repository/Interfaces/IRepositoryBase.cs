using System.Linq.Expressions;
using TesteCI.Models;

namespace TesteCI.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
    }
}
