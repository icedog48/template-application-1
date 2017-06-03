using Autofac;
using Core.Repositories;
using ORM.NHibernate;
using ORM.NHibernate.Helpers;
using System.Configuration;

namespace RestAPI.Infrastructure.Autofac.Modules
{
    public class NhibernateRepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(IRepository<>)).AsImplementedInterfaces();

            //TODO: Register the specific repository implementations here

            base.Load(builder);
        }
    }
}