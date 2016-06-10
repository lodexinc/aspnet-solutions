using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Me.Api.v1.Providers;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Me.Api.v1.Startup))]

namespace Me.Api.v1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(httpConfig);
            app.UseWebApi(httpConfig);            
            app.UseCors(CorsOptions.AllowAll);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(30),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthBearerTokens(OAuthServerOptions);
        }
    }
}
