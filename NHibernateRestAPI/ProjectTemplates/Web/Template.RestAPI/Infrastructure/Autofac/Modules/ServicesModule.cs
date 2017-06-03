using Autofac;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Infrastructure.Autofac.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(IService<>)).AsImplementedInterfaces();

            //TODO: Register the specific service implementations here

            base.Load(builder);
        }
    }
}