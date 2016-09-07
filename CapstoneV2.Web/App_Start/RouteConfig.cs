using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CapstoneV2.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "BlogFilter",
            //    url: "{controller}/Blog/{id}",
            //    defaults: new {controller = "Home", action = "Blog", id = UrlParameter.Optional}
            //);

            routes.MapRoute(
                name: "Blog",
                url: "{controller}/Blog/{id}",
                defaults: new { controller = "Home", action = "Blog", id = UrlParameter.Optional,
                    /*startIndex = 0, pageSize = 2*/ }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
