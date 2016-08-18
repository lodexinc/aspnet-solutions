using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Infrastructure.DependencyResolution
{
    public static class NinjectConfig
    {
        public static void Register(IKernel kernel)
        {
            kernel.Load(new ServiceModule());
            kernel.Load(new RepositoryModule());
        }
    }
}
