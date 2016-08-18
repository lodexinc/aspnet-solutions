using LogiGear.Application.ServiceContracts;
using LogiGear.Application.Services;
using LogiGear.Domain.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IJobSeekerRegistrationAppService>().To<JobSeekerRegistrationAppService>();
            this.Bind<IJobSeekerRegistrationService>().To<JobSeekerRegistrationService>();
        }
    }
}
