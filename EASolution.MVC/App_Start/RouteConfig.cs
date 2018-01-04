using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EASolution.Persistence;

namespace EASolution
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Country", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class DataBase
    {
        public static void Config()
        {
            Database.SetInitializer<ProjectManagementContext>(new CreateDatabaseIfNotExists<ProjectManagementContext>());
        }
    }
}
