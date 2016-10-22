using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACMEsoft.Model;

namespace ACMEsoft.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(ACMEsoftContext)).As(typeof(IContext)).InstancePerLifetimeScope();

        }

    }
}