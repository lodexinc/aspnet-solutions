using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogiGear.MvcApp1.Startup))]
namespace LogiGear.MvcApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
