using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Repositories.Shared
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity Save(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        IQueryable<TEntity> GetAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
    }
}
