using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Autofac;
using EASolution.Model;
using EASolution.Persistence;
using EASolution.Infrastructure.Persistence;

namespace EASolution.Modules
{
    

    public class ProjectManagementConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ProjectManagementContext)).As(typeof(IContext)).InstancePerRequest();
        }

    }
}