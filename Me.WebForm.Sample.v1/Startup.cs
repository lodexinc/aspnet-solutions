using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Me.WebForm.Sample.v1.Startup))]
namespace Me.WebForm.Sample.v1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
