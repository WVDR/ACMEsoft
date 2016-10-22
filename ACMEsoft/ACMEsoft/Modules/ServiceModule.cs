using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace ACMEsoft.Modules
{
    /// <summary>
    /// Register every class the ends with “Service” in Autofac
    /// </summary>
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("ACMEsoft.Service"))

                      .Where(t => t.Name.EndsWith("Service"))

                      .AsImplementedInterfaces()

                      .InstancePerLifetimeScope();

        }

    }
}