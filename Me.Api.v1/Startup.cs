using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Me.Api.v1.Startup))]

namespace Me.Api.v1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            app.UseWebApi(httpConfig);
        }
    }
}
