using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac;
using EASolution.Modules;
using System.Data.Entity;
using EASolution.Model;
using EASolution.Persistence;

namespace EASolution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModuleConfig.RegisterModule();
            DataBase.Config();

            
        }
    }
}
