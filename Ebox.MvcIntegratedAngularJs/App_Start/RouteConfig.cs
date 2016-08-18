using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ebox.MvcIntegratedAngularJs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //                name: "about",
            //                url: "about/{*catch-all}",
            //                defaults: new
            //                {
            //                    controller = "Home",
            //                    action = "about"
            //                });

            //routes.MapRoute(
            //    name: "contact",
            //    url: "contact/{*catch-all}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "contact"
            //    });

            //routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
