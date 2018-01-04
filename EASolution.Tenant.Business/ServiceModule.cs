using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace EASolution.TenantStore.Modules
{
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("EASolution.TenantStore.Service"))
                      .Where(t => t.Name.EndsWith("Service", StringComparison.Ordinal))
                      .AsImplementedInterfaces()
                      .EnableInterfaceInterceptors()
                      .InstancePerLifetimeScope(); 

        }

    }
}