using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EBox.MvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                name: "about",
                url: "Home/About/{donuts}",
                defaults: new { controller = "Home", action = "About", donuts = UrlParameter.Optional });

            routes.MapRoute(
                name: "contact",
                url: "Home/Contact",
                defaults: new { controller = "Home", action = "Contact" });

            routes.MapRoute(
                name: "login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "logout",
                url: "Account/Logout",
                defaults: new { controller = "Account", action = "Logout" });

            routes.MapRoute(
                name: "register",
                url: "Account/Register",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
               name: "resetPassword",
               url: "Account/ResetPassword",
               defaults: new { controller = "Account", action = "ResetPassword" });

            routes.MapRoute(
                name: "externalLinkLogin",
                url: "Account/ExternalLinkLogin",
                defaults: new { controller = "Account", action = "ExternalLinkLogin" });

            routes.MapRoute(
                name: "externalLoginCallback",
                url: "Account/ExternalLoginCallback",
                defaults: new { controller = "Account", action = "ExternalLoginCallback" });


            routes.MapRoute(
                name: "externalLoginConfirmation",
                url: "Account/ExternalLoginConfirmation",
                defaults: new { controller = "Account", action = "ExternalLoginConfirmation" });

            //routes.MapRoute(
            //    name: "externalLoginFailure",
            //    url: "Account/ExternalLoginFailure",
            //    defaults: new { controller = "Account", action = "ExternalLoginFailure" });

            routes.MapRoute(
              name: "verifyEmail",
              url: "Account/Verify",
              defaults: new { controller = "Account", action = "Verify" });

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" });

        }
    }
}
