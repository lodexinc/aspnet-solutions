using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Ebox.MvcIntegratedAngularJs.Repositories;
using Ebox.MvcIntegratedAngularJs.Feature.Authentication;
using Microsoft.Owin.Security;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}