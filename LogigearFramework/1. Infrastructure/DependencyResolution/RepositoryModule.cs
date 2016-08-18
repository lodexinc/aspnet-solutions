using LogiGear.Domain.Repositories;
using LogiGear.Infrastructure.Persistence;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.DependencyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InTransientScope();
            this.Bind<IJobSeekerRepository>().To<JobSeekerRepository>();
        }
    }
}
