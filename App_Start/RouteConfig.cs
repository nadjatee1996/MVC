using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace wb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "home", action = "Index"}
            );
            routes.MapRoute(
                name: "register",
                url: "register",
                defaults: new { controller = "register", action = "Index" }
            );
            routes.MapRoute(
                name: "contact",
                url: "contact",
                defaults: new { controller = "contact", action = "Index" }
            );
            routes.MapRoute(
                name: "login",
                url: "login",
                defaults: new { controller = "home", action = "Login" }
            );

            routes.MapRoute(
                name: "create",
                url: "users/{action}",
                defaults: new { controller = "users", action = "create" }
            );

            routes.MapRoute(
                name: "topics",
                url: "{id}",
                defaults: new { controller = "topic", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "threads",
                url: "{thread}/{id}",
                defaults: new { controller = "thread", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
