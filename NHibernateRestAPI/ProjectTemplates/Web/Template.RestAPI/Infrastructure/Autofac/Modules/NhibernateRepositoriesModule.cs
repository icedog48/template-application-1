using Autofac;
using Template.Core.Repositories;
using Template.ORM.NHibernate.Repositories;
using Template.ORM.NHibernate;
using Template.ORM.NHibernate.Helpers;
using Template.ORM.NHibernate.Repositories;
using System.Configuration;

namespace Template.RestAPI.Infrastructure.Autofac.Modules
{
    public class NhibernateRepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GenericRepository<>).Assembly)
                        .Where(t => t.Name.EndsWith("Repository"))
                            .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}