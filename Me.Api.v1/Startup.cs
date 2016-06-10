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
            // For OWIN pipeline order of your configuration quite important.
            ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            HttpConfiguration httpConfig = new HttpConfiguration();            
            WebApiConfig.Register(httpConfig);
            app.UseWebApi(httpConfig);            
            
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider()                
            };

            // app.UseOAuthBearerTokens(OAuthServerOptions);

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
