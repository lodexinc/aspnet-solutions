using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiGear.Domain.Repositories.Shared;

namespace LogiGear.Infrastructure.Persistence
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private static EBoxDbContext _dpsDbContext;

        private static EBoxDbContext DbContextInstance()
        {
            if (_dpsDbContext == null)
            {
                _dpsDbContext = new EBoxDbContext();
            }

            return _dpsDbContext;
        }

        public void Commit()
        {
            _dpsDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dpsDbContext.Dispose();
        }

        IRepository<T> IUnitOfWork.RepositoryOf<T>()
        {
            return new EFRepository<T>(DbContextInstance());
        }
    }
}
