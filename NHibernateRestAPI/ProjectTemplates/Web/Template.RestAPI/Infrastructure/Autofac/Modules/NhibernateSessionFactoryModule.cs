using Autofac;
using FluentMigrator.Runner.Processors.SqlServer;
using Template.ORM.NHibernate.Repositories;
using Migrations.Helpers;
using NHibernate;
using Template.ORM.NHibernate.Helpers;
using System.Configuration;

namespace Template.RestAPI.Infrastructure.Autofac.Modules
{
    public class NhibernateSessionFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            Runner.MigrateToLatest<SqlServer2014ProcessorFactory>(connectionString);

            var sessionFactory = SessionFactoryHelper.GetMsSqlServerSessionFactory(connectionString);

            builder.RegisterInstance(sessionFactory);

            builder.Register(context => 
                    {
                        var session = context.Resolve<ISessionFactory>().OpenSession();

                        session.FlushMode = FlushMode.Commit;

                        return session;
                    })
                   .InstancePerRequest();

            builder.RegisterType<NHibernateUnitOfWork>().AsImplementedInterfaces().InstancePerRequest();

            base.Load(builder);
        }
    }
}