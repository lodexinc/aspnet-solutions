using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EBox.MvcApp.Providers
{
    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            
            var fbEmailEndPoint = string.Format("https://graph.facebook.com/me?fields=id,name,email&access_token={0}", context.AccessToken);
            var uri = new Uri(fbEmailEndPoint);
            HttpClient client = new HttpClient();

            var response = client.GetAsync(uri);
            response.Wait();
            var content = response.Result.Content.ReadAsStringAsync();
            content.Wait();

            dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content.Result.ToString());
            string email = jObj["email"];

            context.Identity.AddClaim(new Claim("Email", email));
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            // var client = new FacebookClient(context.AccessToken);
            //dynamic info = client.Get("me", new { fields = "name,id,email" });
            return Task.FromResult<object>(null);
        }
    }
}