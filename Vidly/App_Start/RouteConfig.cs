using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Controllers;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //attribute routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                //name of route
                "Show Customers",
                //url of route
                "Customers",
                //specifying the defaults
                new { controller = "Customers", action = "Index"}
                );


            // define custom route before default route. Order matters! 
            routes.MapRoute(
                //name of route
                "MoviesByReleaseDate",
                //url of route
                "movies/released/{year}/{month}",
                //specifying the defaults
                new { controller = "Movies", action ="ByReleaseDate" },
                //applying constraints
                new { year = @"\d{4}", month = @"\d{2}"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
