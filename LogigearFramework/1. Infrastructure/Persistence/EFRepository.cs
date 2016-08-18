using LogiGear.Domain.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.Persistence
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EBoxDbContext _eboxDbContext;

        public EFRepository(EBoxDbContext eboxDbContext)
        {
            if (eboxDbContext == null) throw new ArgumentNullException("unitOfWork");
            this._eboxDbContext = eboxDbContext;
        }

        public EBoxDbContext UnitOfWork
        {
            get { return _eboxDbContext; }
        }

        public TEntity Save(TEntity entity)
        {
            if (entity != (TEntity)null)
            {
                this._eboxDbContext.Set<TEntity>().Add(entity);
            }

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity != (TEntity)null)
            {
                _eboxDbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            }

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity != (TEntity)null)
            {
                _eboxDbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
                this._eboxDbContext.Set<TEntity>().Remove(entity);
            }

            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _eboxDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return _eboxDbContext.Set<TEntity>().Where(filter);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
