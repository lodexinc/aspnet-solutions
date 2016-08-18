using LogiGear.Domain.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepository<T> RepositoryOf<T>() where T : class;
    }
}
