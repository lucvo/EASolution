using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EASolution.Modules;
using EASolution.Infrastructure.Logging;
using Serilog;

namespace EASolution
{
    public class ModuleConfig
    {
        public static void RegisterModule()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new LoggerModule());
            builder.RegisterModule(new ServiceModule());
            
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}