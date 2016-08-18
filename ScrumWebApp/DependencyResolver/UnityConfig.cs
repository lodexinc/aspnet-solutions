using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Scrum.Application;
using Scrum.EntityFramework;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace ScrumWebApp
{
    public class UnityConfig
    {

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IRegistrationService, RegistrationService>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}