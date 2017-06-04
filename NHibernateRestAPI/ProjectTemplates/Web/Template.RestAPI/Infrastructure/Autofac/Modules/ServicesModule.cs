using Autofac;
using Template.Core.Models;
using Template.Core.Services;
using Template.Core.Services.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.RestAPI.Infrastructure.Autofac.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DefaultService<>)).AsImplementedInterfaces();

            //Registra implementações fechadas (não genéricas) de IService
            builder.RegisterAssemblyTypes(typeof(_Entity).Assembly)
                        .Where(t => t.Name.EndsWith("Service"))
                            .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();

            //Registra implementações fechadas (não genéricas) de IService
            builder.RegisterAssemblyTypes(typeof(_Entity).Assembly)
                        .Where(t => t.Name.EndsWith("Validator"))
                            .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}